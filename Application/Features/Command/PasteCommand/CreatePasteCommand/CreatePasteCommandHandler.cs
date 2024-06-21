using Application.Services.ApplicationExceptions;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Identity;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistance.Abstractions.Pastes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Features.Command.PasteCommand.CreatePasteCommand
{
    public class CreatePasteCommandHandler : IRequestHandler<CreatePasteCommandRequest, CreatePasteCommandResponse>
    {
        private readonly IHttpContextAccessor _contextAccessor;
        UserManager<AppUser> _userManager;
        IPasteWriteRepository _pasteWriteRepository;
        IMapper _mapper;
        public CreatePasteCommandHandler(IPasteWriteRepository pasteWriteRepository, IMapper mapper, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _pasteWriteRepository = pasteWriteRepository;
            _mapper = mapper;
            _userManager = userManager;
            _contextAccessor = httpContextAccessor;
        }

        public async Task<CreatePasteCommandResponse> Handle(CreatePasteCommandRequest request, CancellationToken cancellationToken)
        {
            
            CreatePasteCommandResponse response = new CreatePasteCommandResponse();
            
            var paste = _mapper.Map<Paste>(request);

            if(string.IsNullOrEmpty(paste.Content) && string.IsNullOrEmpty(paste.Title)) 
            {
                throw new PasteException(PasteExceptions.TitleAndContentisNull);
            }

            string userId = _contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            paste.AppUserId = userId!=null ? userId : Constants.ApplicationConstants.AnonymId;

            var res = await _pasteWriteRepository.Add(paste);
            var result = _pasteWriteRepository.SaveAsync();
            if (res == false || result != 1)
                throw new PasteException(PasteExceptions.DbError);
            

            response = _mapper.Map<CreatePasteCommandResponse>(paste);
            return response;
        }
    }
}
