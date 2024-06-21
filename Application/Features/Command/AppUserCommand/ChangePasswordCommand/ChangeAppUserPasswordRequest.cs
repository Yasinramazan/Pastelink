using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Command.AppUserCommand.ChangePasswordCommand
{
    public class ChangeAppUserPasswordRequest:IRequest<ChangeAppUserPasswordResponse>
    {
        public string UserId { get; set; }
        public string NewPassword { get; set; }
        public string Password { get; set; }
    }
}
