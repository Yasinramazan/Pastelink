using Application.Features.Command.AppUserCommand.CreateAppUser;
using Application.Features.Command.PasteCommand.CreatePasteCommand;
using Application.Features.Command.PasteCommand.UpdatePasteCommand;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mapper
{
    public class CreatePasteResponseMapper:Profile
    {
        public CreatePasteResponseMapper()
        {
            CreateMap<Paste, CreatePasteCommandResponse>()
                .ForMember(paste => paste.Id, req => req.MapFrom(src => src.Id))
                .ForMember(paste => paste.Title, req => req.MapFrom(src => src.Title))
                .ForMember(paste => paste.Content, req => req.MapFrom(src => src.Content))
                .ForMember(paste => paste.IsPublic, req => req.MapFrom(src => src.IsPublic))
                .ForMember(paste => paste.CreatedTime, req => req.MapFrom(src => src.CreatedTime))
                .ForMember(paste => paste.UpdatedTime, req => req.MapFrom(src => src.UpdatedTime));
        }
    }
}
