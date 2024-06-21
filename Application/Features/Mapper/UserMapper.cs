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
    public class UserMapper:Profile
    {
        public UserMapper()
        {
            CreateMap<CreateAppUserRequest, AppUser>()
                .ForMember(user => user.Id, req => Guid.NewGuid())
                .ForMember(user=>user.UserName,req=>req.MapFrom(src=>src.EMail))
                .ForMember(user => user.Email, req => req.MapFrom(src => src.EMail));
                
        }
    }
}
