using Application.Features.Command.AppUserCommand.CreateAppUser;
using Application.Features.Command.PasteCommand.CreatePasteCommand;
using Application.Features.Command.PasteCommand.UpdatePasteCommand;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mapper
{
    public class PasteMapper:Profile
    {
        public PasteMapper()
        {
            CreateMap<CreatePasteCommandRequest, Paste>()
                .ForMember(paste => paste.Id, req => Guid.NewGuid())
                .ForMember(paste => paste.Title, req => req.MapFrom(src => src.Title))
                .ForMember(paste => paste.Content, req => req.MapFrom(src => src.Content))
                .ForMember(paste => paste.IsPublic, req => req.MapFrom(src => src.IsPublic));



            CreateMap<UpdatePasteCommandRequest, Paste>()
                .ForMember(paste => paste.Id, req => Guid.NewGuid())
                .ForMember(paste => paste.Title, req => req.MapFrom(src => src.Title))
                .ForMember(paste => paste.Content, req => req.MapFrom(src => src.Content))
                .ForMember(paste => paste.IsPublic, req => req.MapFrom(src => src.IsPublic))
                .ForMember(paste => paste.IsLocked, req => req.MapFrom(src => src.IsLocked));
                
        }
    }
}
