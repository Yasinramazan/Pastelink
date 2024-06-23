using Application.Abstractions.Token;
using Application.DTOs;
using Application.Features.Command.AppUserCommand.CreateAppUser;
using Application.Services.ApplicationExceptions;
using AutoMapper;
using Domain.Entities.Identity;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Command.AppUserCommand.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
    {
        private IHttpContextAccessor _httpContextAccessor;
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        

        private readonly IMapper _mapper;
        private ITokenHandler _tokenHandler;

        public LoginUserHandler(UserManager<AppUser> userManager, IMapper mapper, ITokenHandler tokenHandler, SignInManager<AppUser> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenHandler = tokenHandler;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {

            var user =await _userManager.FindByEmailAsync(request.Email);
            
            if(user==null)
            {
                throw new UserException(UserExceptions.UserNotFound);
            }
            SignInResult result = await _signInManager.PasswordSignInAsync(user,request.Password,false,false);

            if(result.Succeeded)
            {
                Token token = _tokenHandler.CreateAccessToken(user);
               return new LoginUserResponse()
                {
                    Id=user.Id,
                    Email=user.Email,
                    Token = token,
                };
            }

            throw new UserException(UserExceptions.LoginFailed);
        }
    }
}
