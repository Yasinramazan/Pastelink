using MediatR;
using Microsoft.AspNetCore.Http;
using Persistance.Abstractions.Pastes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Command.PasteQuery.GetAllPastesQuery
{
    public class GetAllPastesQueryHandler : IRequestHandler<GetAllPastesQueryRequest, GetAllPastesQueryResponse>
    {
        private readonly IPasteReadRepository _pasteReadRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public GetAllPastesQueryHandler(IPasteReadRepository pasteReadRepository, IHttpContextAccessor contextAccessor)
        {
            _pasteReadRepository = pasteReadRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<GetAllPastesQueryResponse> Handle(GetAllPastesQueryRequest request, CancellationToken cancellationToken)
        {
            GetAllPastesQueryResponse response = new();
            response.Pastes = new List<Domain.Entities.Paste>();
            var result = _pasteReadRepository.GetAll();

            if (result == null)
                throw new Exception();
            foreach (var item in result)
            {
                if(item.AppUserId == _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier))
                    response.Pastes.Add(item); 
            }

            return response;
        }
    }
}
