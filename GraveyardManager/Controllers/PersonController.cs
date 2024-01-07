using GraveyardManager.Model;
using GraveyardManager.Requests.Persons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GraveyardManager.Controllers
{
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
        public async Task<IActionResult> SearchPerson(SearchPersonRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
