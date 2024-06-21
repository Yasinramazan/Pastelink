﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Command.PasteCommand.BanPasteCommand
{
    public class BanPasteCommandRequest:IRequest<BanPasteCommandResponse>
    {
        public string PasteId { get; set; }
    }
}
