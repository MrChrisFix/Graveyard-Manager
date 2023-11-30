using GraveyardManager.Model;
using GraveyardManager.Requesters.Graveyards;
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

        [HttpGet]
        [Route("/{Id}")]
        public async Task<IActionResult> GetGraveyard(int Id)
        {
            var result = await _mediator.Send(new GetGraveyardRequest(Id));

            return Ok(result);
        }

        [HttpPost]
        [Route("/")]
        public async Task<IActionResult> CreateGraveyard()
        {
            var result = await _mediator.Send(new CreateGraveyardRequest());

            return Created(Request.Path, result);
        }

        [HttpPost]
        [Route("/{GraveyardId}/plot")]
        public async Task<IActionResult> AddPlot(int GraveyardId, Plot plot)
        {
            var result = await _mediator.Send(new AddPlotRequest(GraveyardId, plot));
            return Ok(result);
        }
    }
}
