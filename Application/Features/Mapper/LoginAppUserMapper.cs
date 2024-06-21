using Application.Features.Command.AppUserCommand.CreateAppUser;
using Application.Features.Command.AppUserCommand.LoginUser;
using AutoMapper;
using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mapper
{
    public class LoginAppUserMapper:Profile
    {
        public LoginAppUserMapper()
        {
            CreateMap<AppUser, LoginUserResponse>()
               .ForMember(user => user.Id, req => req.MapFrom(src => src.Id))
               .ForMember(user => user.Email, req => req.MapFrom(src => src.Email));
        }
    }
}
