using GraveyardManager.Model;
using GraveyardManager.Requests.Graves;
using GraveyardManager.Requests.Persons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GraveyardManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GraveController : Controller
    {
        private readonly IMediator _mediator;

        public GraveController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetGraveInfo(int id)
        {
            var response = await _mediator.Send(new GetGraveRequest(id));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewGrave(CreateGraveRequest request)
        {
            var result = await _mediator.Send(request);
            return Created(Request.Path, result);
        }

        [HttpPatch("{id}/modifyPerson")]
        public async Task<IActionResult> ModifyPerson(int id, PersonDTO personDTO)
        {
            //TODO: move this endpoint to a PersonController
            var result = await _mediator.Send(new ModifyPersonRequest(id, personDTO));
            return Ok(result);
        }

        [HttpPut("addPerson")]
        public async Task<IActionResult> AddPersonToGrave(AddPersonRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        //Standard grave removal (eg. because it wasn't paid) -> Soft delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveGrave(int id, DateOnly? removalDate)
        {
            DateOnly removal = removalDate ?? DateOnly.FromDateTime(DateTime.Now);
            await _mediator.Send(new RemoveGraveRequest(id, removal));

            return NoContent();
        }

        //Removal of accidentally added graves -> Hard delete
        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> DeleteGrave(int id)
        {
            await _mediator.Send(new DeleteAccidentalGraveRequest(id));
            return NoContent();
        }

        [HttpPatch("{id}/pay")]
        public async Task<IActionResult> PayForGrave(int id, DateOnly paidUntil)
        {
            var response = await _mediator.Send(new PayForGraveRequest(id, paidUntil));
            return Ok(response);
        }
    }
}
