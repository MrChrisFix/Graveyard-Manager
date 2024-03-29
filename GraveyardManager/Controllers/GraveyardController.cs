﻿using GraveyardManager.Model;
using GraveyardManager.Requests.Graveyards;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GraveyardManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GraveyardController : ControllerBase
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

        /*[HttpPost("{id}/columbarium")]
        public async Task<IActionResult> AddColumbarium(int id, Columbarium columbarium)
        {
            var result = await _mediator.Send(new AddColumbariumRequest(id, columbarium));

            return Created(Request.Path, result);
        }*/

        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeOwnerInformation(int id, GraveyardOwner owner)
        {
            var response = await _mediator.Send(new ChangeOwnerRequest(id, owner));

            return Ok(response);
        }

    }
}
