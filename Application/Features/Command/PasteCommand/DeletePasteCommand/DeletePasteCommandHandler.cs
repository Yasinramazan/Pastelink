using MediatR;
using Persistance.Abstractions.Pastes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Command.PasteCommand.DeletePasteCommand
{
    public class DeletePasteCommandHandler : IRequestHandler<DeletePasteCommandRequest, DeletePasteCommandResponse>
    {
        IPasteWriteRepository _pasteWriteRepository;
        IPasteReadRepository _pasteReadRepository;

        public DeletePasteCommandHandler(IPasteWriteRepository pasteWriteRepository, IPasteReadRepository pasteReadRepository)
        {
            _pasteWriteRepository = pasteWriteRepository;
            _pasteReadRepository = pasteReadRepository;
        }

        public async Task<DeletePasteCommandResponse> Handle(DeletePasteCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var model = await _pasteReadRepository.GetById(request.Id);
                var result = await _pasteWriteRepository.Delete(model);
                _pasteWriteRepository.SaveAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return new();
        }
    }
}
