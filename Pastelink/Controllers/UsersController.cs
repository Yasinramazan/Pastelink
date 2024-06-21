using Application.Features.Command.AppUserCommand.CreateAppUser;
using Application.Features.Command.AppUserCommand.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Application.Features.Command.AppUserCommand.LogOutUser;
using Application.Features.Command.AppUserCommand.ChangePasswordCommand;
using Microsoft.AspNetCore.Authorization;


namespace Pastelink.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class UsersController : Controller
    {

        private readonly IMediator _mediator;
        
      
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
            
        }

        [HttpPost("SignUpUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateAppUserRequest request)
        { 
            CreateAppUserResponse response = await _mediator.Send(request);
            
            if(response.Message.Count() > 0)
            {
                Response.StatusCode = 400;
                return Json(response);
            }
            
            return Ok(response);
        }

        [HttpPost("LoginUser")]
        public async Task<IActionResult> LoginUser(LoginUserRequest request)
        {
            
            var user = await _mediator.Send(request);
            return Ok(user);
        }

        [HttpGet("LogoutUser")]
        public async Task<IActionResult> LogoutUser(LogoutUserRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("ChangeUserPassword")]
        public async Task<IActionResult> ChangeUserPassword(ChangeAppUserPasswordRequest request)
        {
            ChangeAppUserPasswordResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
