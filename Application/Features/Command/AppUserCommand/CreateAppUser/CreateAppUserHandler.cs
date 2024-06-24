using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Application.Services.ApplicationExceptions;
using Persistance.Abstractions.UserAbstractions;

namespace Application.Features.Command.AppUserCommand.CreateAppUser
{
    public class CreateAppUserHandler: IRequestHandler<CreateAppUserRequest, CreateAppUserResponse>
    {
        private readonly IUserService<AppUser> _userService;
        private readonly IMapper _mapper;

        public CreateAppUserHandler(IMapper mapper, IUserService<AppUser> userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<CreateAppUserResponse> Handle(CreateAppUserRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<AppUser>(request);


            
            IdentityResult result =  await _userService.CreateAsync(user,request.Password);
            CreateAppUserResponse response = new CreateAppUserResponse();
            
            if (result.Succeeded)
            {
                response = _mapper.Map<CreateAppUserResponse>(user);
                response.Message = new();
                return response;
            }
            else
            {
                response.Message = new List<string>();
                foreach (var error in result.Errors)
                {
                    response.Message.Add(error.Description);
                }
            }
            return response;
        }
    }
}
