using GraveyardManager.Model;
using GraveyardManager.Requesters.Graves;
using GraveyardManager.Requesters.Persons;
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


        [HttpGet("/Grave/{Id}")]
        public async Task<IActionResult> GetGraveInfo(int Id)
        {
            var response = await _mediator.Send(new GetGraveRequest(Id));
            return Ok(response);
        }

        [HttpPost("/Grave")]
        public async Task<IActionResult> CreateNewGrave(Grave grave)
        {
            var result = await _mediator.Send(new CreateGraveRequest(grave));
            return Created(Request.Path, result);
        }

        [HttpPatch]
        [Route("/{GraveId}/modifyPerson")]
        public async Task<IActionResult> ModifyPerson(int GraveId, PersonDTO personDTO)
        {
            var result = await _mediator.Send(new ModifyPersonRequest(GraveId, personDTO));
            return Ok(result);
        }

        [HttpPut]
        [Route("/{GraveId}/addPerson")]
        public async Task<IActionResult> AddPersonToGrave(int GraveId, Person Person)
        {
            var result = await _mediator.Send(new AddPersonRequest(GraveId, Person));
            return Ok(result);
        }

        //Standard grave removal (eg. becouse it wasn't paid)
        [HttpDelete("/Grave/{Id}")]
        public async Task<IActionResult> RemoveGrave(int Id, DateOnly? removalDate)
        {
            DateOnly removal = removalDate ?? DateOnly.FromDateTime(DateTime.Now);
            var response = await _mediator.Send(new RemoveGraveRequest(Id, removal));

            return Ok(response);
        }

        //Removal of accidentally added graves
        [HttpDelete("/Grave/delete/{Id}")]
        public async Task<IActionResult> DeleteAccidentalGrave(int Id)
        {
            var resposne = await _mediator.Send(new DeleteAccidentalGraveRequest(Id));

            return Ok(resposne);
        }
    }
}
