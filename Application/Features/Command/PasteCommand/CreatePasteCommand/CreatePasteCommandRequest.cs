using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Command.PasteCommand.CreatePasteCommand
{
    public class CreatePasteCommandRequest:IRequest<CreatePasteCommandResponse>
    { 
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsPublic { get; set; }
        public string? CustomURL { get; set; }
        public DateTime? ExpireTime { get; set; }
       
    }
}
