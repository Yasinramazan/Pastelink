using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Command.AppUserCommand.CreateAppUser
{
    public class CreateAppUserRequest:IRequest<CreateAppUserResponse>
    {
        
        public string EMail { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
