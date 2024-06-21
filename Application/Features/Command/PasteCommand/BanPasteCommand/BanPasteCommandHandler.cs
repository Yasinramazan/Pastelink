using MediatR;
using Persistance.Abstractions.Pastes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Command.PasteCommand.BanPasteCommand
{
    public class BanPasteCommandHandler : IRequestHandler<BanPasteCommandRequest, BanPasteCommandResponse>
    {
        private readonly IPasteReadRepository _PasteReadRepository;
        private IPasteWriteRepository _PasteWriteRepository;

        public BanPasteCommandHandler(IPasteReadRepository pasteReadRepository, IPasteWriteRepository pasteWriteRepository)
        {
            _PasteReadRepository = pasteReadRepository;
            _PasteWriteRepository = pasteWriteRepository;
        }

        public Task<BanPasteCommandResponse> Handle(BanPasteCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
