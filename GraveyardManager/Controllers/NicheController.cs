using GraveyardManager.Model;
using GraveyardManager.Requests.Niches;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GraveyardManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NicheController : Controller
    {
        readonly IMediator _mediator;

        public NicheController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _mediator.Send(new GetNicheRequest(id));
            return Ok(response);
        }

        //Niche creation is at columbarium creation

        [HttpPut("{id}/addPerson")]
        public async Task<IActionResult> AddPersonToNiche(int id, Person person)
        {
            var response = await _mediator.Send(new AddPersonRequest(id, person));
            return Ok(response);
        }

        [HttpPatch("{id}/clear")]
        public async Task<IActionResult> ClearNiche(int id)
        {
            var response = await _mediator.Send(new ClearNicheRequest(id));
            return Ok(response);
        }

        [HttpPatch("{id}/pay")]
        public async Task<IActionResult> PayForNiche(int id, DateOnly paidUntil)
        {
            var response = await _mediator.Send(new PayForNicheRequest(id, paidUntil));
            return Ok(response);
        }
    }
}
