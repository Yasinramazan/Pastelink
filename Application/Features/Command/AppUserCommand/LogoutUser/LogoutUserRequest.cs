using Application.Features.Command.AppUserCommand.LogoutUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Command.AppUserCommand.LogOutUser
{
    public class LogoutUserRequest:IRequest<LogoutUserResponse>
    {
        public string Id { get; set; }
    }
}
