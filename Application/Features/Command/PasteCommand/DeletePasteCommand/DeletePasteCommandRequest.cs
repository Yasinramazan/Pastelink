using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Command.PasteCommand.DeletePasteCommand
{
    public class DeletePasteCommandRequest:IRequest<DeletePasteCommandResponse>
    {
        public string Id { get; set; }
    }
}
