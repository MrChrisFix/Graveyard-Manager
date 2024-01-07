using GraveyardManager.Model;
using GraveyardManager.Requests.Persons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GraveyardManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : Controller
    {
        readonly IMediator _mediator;
        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPatch]
        public async Task<IActionResult> ModifyPerson(ModifyPersonRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchPerson(
            [FromQuery]string? firstName,
            [FromQuery] string? lastName,
            [FromQuery] DateOnly? dateFrom,
            [FromQuery] DateOnly? dateTo
            )
        {
            var response = await _mediator.Send(new SearchPersonRequest(firstName,lastName,dateFrom,dateTo));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddPersonToGrave(AddPersonRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
