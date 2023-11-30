using GraveyardManager.Data;
using GraveyardManager.Model;
using GraveyardManager.Exceptions;
using MediatR;

namespace GraveyardManager.Requesters.Graveyards
{
    public record AddPlotRequest(int GYId, Plot Plot) : IRequest<Plot> { }

    public class AddPlotRequestHandler : IRequestHandler<AddPlotRequest, Plot>
    {
        GraveDbContext _context;

        public AddPlotRequestHandler(GraveDbContext context) 
        {
            _context = context;
        }

        public Task<Plot> Handle(AddPlotRequest request, CancellationToken cancellationToken)
        {
            Graveyard graveyard = _context.Graveyards.Find(request.GYId, cancellationToken) ?? throw new NotFoundException("Graveyard not found");

            graveyard.Plots.Add(request.Plot);

            _context.SaveChanges();

            return Task.FromResult(request.Plot);
        }
    }
}
