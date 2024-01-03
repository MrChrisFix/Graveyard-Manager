using GraveyardManager.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GraveyardManager.Controllers
{
    public class PlotController : Controller
    {
        readonly IMediator _mediator;

        public PlotController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }

        //The creation endpoint is in GraveyardController


        [HttpPatch("{id}")]
        public async Task<IActionResult> ModifyPlot(int id, Plot plot)
        {
            //Idk what to modify, but an endpoint exists
            throw new NotImplementedException();
        }

        //Soft delete with cascading grave soft delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemovePlot(int id, int plotId)
        {
            throw new NotImplementedException();
        }

        //Hard delete with cascading grave hard delete
        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> DeletePlot(int id)
        {
            throw new NotImplementedException();
        }
    }
}
