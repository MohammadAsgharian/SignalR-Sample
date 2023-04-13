using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR_Sample.WebApi.Application.People;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SignalR_Sample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> Get(string username)
        {
            try
            {
                var request =
                    new GetTokenQuery(username);
                var result = await _mediator.Send(request);

                return Ok(result);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }

        }
    }
}
