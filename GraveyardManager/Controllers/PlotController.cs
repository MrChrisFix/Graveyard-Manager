using GraveyardManager.Model;
using GraveyardManager.Requests.Plots;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GraveyardManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlotController : Controller
    {
        readonly IMediator _mediator;

        public PlotController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNiche(int id)
        {
            var response = await _mediator.Send(new GetPlotRequest(id));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddPlot(AddPlotRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> ModifyPlot(int id, Plot plot)
        {
            throw new NotImplementedException("No purpose yet");
        }

        //Soft delete with cascading grave soft delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemovePlot(int id, DateOnly removalDay)
        {
            await _mediator.Send(new RemovePlotRequest(id, removalDay));
            return NoContent();
        }
    }
}
