using Application.Constants;
using Application.Services.ApplicationExceptions;
using Domain.Exceptions;
using MediatR;
using Persistance.Abstractions.Pastes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Command.PasteQuery.GetPastebyIdQuery
{
    public class GetPasteByIdQueryHandler : IRequestHandler<GetPasteByIdQueryRequest, GetPasteByIdQueryResponse>
    {
        private readonly IPasteReadRepository _pasteReadRepository;

        public GetPasteByIdQueryHandler(IPasteReadRepository pasteReadRepository)
        {
            _pasteReadRepository = pasteReadRepository;
        }

        public async Task<GetPasteByIdQueryResponse> Handle(GetPasteByIdQueryRequest request, CancellationToken cancellationToken)
        {
            GetPasteByIdQueryResponseModel response = new();
            response.Model = await _pasteReadRepository.GetById(request.Id);

            if (response.Model == null)
            {
                throw new PasteException(PasteExceptions.PasteNoFound);
            }

            if (response.Model.IsLocked)
            {
                return new GetPasteByIdQueryResponseLockMessage()
                { Message=ApplicationConstants.LockMessage};
            }

            return response;

        }
    }
}
