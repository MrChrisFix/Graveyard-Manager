using GraveyardManager.Data;
using GraveyardManager.Model;
using GraveyardManager.Exceptions;
using MediatR;

namespace GraveyardManager.Requests.Graveyards
{
    public record AddPlotRequest(int GyId, Plot Plot) : IRequest<Plot> { }

    public class AddPlotRequestHandler : IRequestHandler<AddPlotRequest, Plot>
    {
        GraveDbContext _context;

        public AddPlotRequestHandler(GraveDbContext context) 
        {
            _context = context;
        }

        public async Task<Plot> Handle(AddPlotRequest request, CancellationToken cancellationToken)
        {
            Graveyard graveyard = _context.Graveyards.Find(request.GyId) ?? throw new NotFoundException("Graveyard not found");

            await _context.Plots.AddAsync(request.Plot, cancellationToken);

            graveyard.Plots.Add(request.Plot);

            await _context.SaveChangesAsync(cancellationToken);

            return request.Plot;
        }
    }
}
