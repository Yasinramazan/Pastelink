﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Command.AppUserCommand.CreateAppUser
{
    public class CreateAppUserResponse
    {
        public string Email { get; set; }
        public List<string> Message { get; set; }
    }
}
