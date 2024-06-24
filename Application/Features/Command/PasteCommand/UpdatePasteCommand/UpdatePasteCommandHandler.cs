using Persistance.Abstractions.UserAbstractions;
using AutoMapper;
using Azure;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using Persistance.Abstractions.Pastes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.ApplicationExceptions;

namespace Application.Features.Command.PasteCommand.UpdatePasteCommand
{
    public class UpdatePasteCommandHandler : IRequestHandler<UpdatePasteCommandRequest, UpdatePasteCommandResponse>
    {
        private readonly IPasteReadRepository _pasteRepository;
        private IPasteWriteRepository _pasteWriteRepository;
        private readonly IMapper _mapper;
        ILogger<UpdatePasteCommandHandler> _logger;

        public UpdatePasteCommandHandler(IPasteReadRepository pasteRepository, IMapper mapper, IPasteWriteRepository pasteWriteRepository, ILogger<UpdatePasteCommandHandler> logger)
        {
            _pasteRepository = pasteRepository;
            _mapper = mapper;
            _pasteWriteRepository = pasteWriteRepository;
            _logger = logger;
        }

        public async Task<UpdatePasteCommandResponse> Handle(UpdatePasteCommandRequest request, CancellationToken cancellationToken)
        {
            UpdatePasteCommandResponse response= new UpdatePasteCommandResponse();
            Paste paste = await _pasteRepository.GetById(request.Id);
            
            if(paste is null)
            {
                throw new PasteException(PasteExceptions.PasteNoFound);
            }

            string UserId = paste.AppUserId;
            DateTime CreatedTime = paste.CreatedTime;
            paste = _mapper.Map<Paste>(request);
            paste.CreatedTime = CreatedTime;
            paste.AppUserId = UserId;

            var result = await _pasteWriteRepository.Update(paste);
            var saveResult = _pasteWriteRepository.SaveAsync();
            response = _mapper.Map<UpdatePasteCommandResponse>(paste);
            
            return response;
        }
    }
}
