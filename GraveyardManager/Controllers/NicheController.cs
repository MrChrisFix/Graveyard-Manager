using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GraveyardManager.Controllers
{
    public class NicheController : Controller
    {
        readonly IMediator _mediator;

        public NicheController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
