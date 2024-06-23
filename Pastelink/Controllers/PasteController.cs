using Application.Features.Command.PasteCommand.CreatePasteCommand;
using Application.Features.Command.PasteCommand.UpdatePasteCommand;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Application.Features.Command.PasteCommand.DeletePasteCommand;
using Application.Features.Command.PasteQuery.GetPastebyIdQuery;
using Application.Features.Command.PasteQuery.GetAllPastesQuery;

namespace Pastelink.Controllers
{
    //[EnableCors("OpenCORSPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class PasteController : Controller
    {
        IMediator _mediator;

        public PasteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("CreatePaste")]
        public async Task<IActionResult> CreatePaste(CreatePasteCommandRequest request)
        {
            var t = User.Identity.Name;
            var response = _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("GetPastes")]
        public async Task<IActionResult> GetPastes([FromQuery]GetAllPastesQueryRequest request)
        {
            GetAllPastesQueryResponse response =  await _mediator.Send(request);
            return Ok(response);

        }

        [HttpGet("GetPaste")]
        public async Task<IActionResult> GetIdPaste(GetPasteByIdQueryRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPut("UpdatePaste")]
        public async Task<IActionResult> UpdatePaste(UpdatePasteCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpDelete("DeletePaste")]
        public async Task<IActionResult> DeletePaste(DeletePasteCommandRequest request)
        {
            DeletePasteCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("LockPaste")]
        public async Task<IActionResult> LockPaste(UpdatePasteCommandRequest request)
        {
            request.IsLocked = true;
            await _mediator.Send(request);
            return Ok();
        }

    }
}
