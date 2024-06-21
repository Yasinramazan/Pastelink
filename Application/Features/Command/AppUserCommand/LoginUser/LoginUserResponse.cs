using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Command.AppUserCommand.LoginUser
{
    public class LoginUserResponse
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public Token Token { get; set; }

    }
}
