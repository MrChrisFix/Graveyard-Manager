using GraveyardManager.Model;
using GraveyardManager.Requests.Graveyards;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GraveyardManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GraveyardController : Controller
    {
        readonly IMediator _mediator;

        public GraveyardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGraveyard(int id)
        {
            var result = await _mediator.Send(new GetGraveyardRequest(id));

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGraveyard(CreateGraveyardRequest request)
        {
            var result = await _mediator.Send(request);

            return Created(Request.Path, result);
        }

        [HttpPost("{id}/plot")]
        public async Task<IActionResult> AddPlot(int id, Plot plot)
        {
            var result = await _mediator.Send(new AddPlotRequest(id, plot));
            return Ok(result);
        }
    }
}
