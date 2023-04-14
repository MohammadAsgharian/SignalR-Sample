using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR_Sample.WebApi.Application.Commands;
using SignalR_Sample.WebApi.Application.Queries;

namespace SignalR_Sample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    { 
        public readonly IMediator _mediator;

        public MessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost()]
        public async Task<IActionResult> Post(CreateMessageCommand request)
        {
            try
            {
                var result = await _mediator.Send(request);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
