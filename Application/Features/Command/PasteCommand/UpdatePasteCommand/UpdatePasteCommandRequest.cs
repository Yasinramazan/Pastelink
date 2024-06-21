using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Command.PasteCommand.UpdatePasteCommand
{
    public class UpdatePasteCommandRequest:IRequest<UpdatePasteCommandResponse>
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsPublic { get; set; }
        public string? CustomURL { get; set; }
        public DateTime? ExpireTime { get; set; }
        public bool IsLocked = false;

    }
}
