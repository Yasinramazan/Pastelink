using Application.Features.Command.AppUserCommand.CreateAppUser;
using AutoMapper;
using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mapper
{
    public class CreateAppUserRequestMapper:Profile
    {
        public CreateAppUserRequestMapper()
        {
            CreateMap<AppUser, CreateAppUserResponse>()
               .ForMember(user => user.Email, req => req.MapFrom(src => src.Email));
               
        }
    }
}
