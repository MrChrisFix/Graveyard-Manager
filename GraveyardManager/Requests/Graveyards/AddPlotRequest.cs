using GraveyardManager.Data;
using GraveyardManager.Model;
using GraveyardManager.Exceptions;
using MediatR;

namespace GraveyardManager.Requests.Graveyards
{
    public record AddPlotRequest(int Id, Plot Plot) : IRequest<Plot> { }

    public class AddPlotRequestHandler : IRequestHandler<AddPlotRequest, Plot>
    {
        GraveyardDbContext _context;

        public AddPlotRequestHandler(GraveyardDbContext context) 
        {
            _context = context;
        }

        public async Task<Plot> Handle(AddPlotRequest request, CancellationToken cancellationToken)
        {
            Graveyard graveyard = await _context.Graveyards.FindAsync(request.Id, cancellationToken) 
                ?? throw new NotFoundException($"Graveyard with the id {request.Id} was not found");

            await _context.Plots.AddAsync(request.Plot, cancellationToken);

            graveyard.Plots.Add(request.Plot);

            await _context.SaveChangesAsync(cancellationToken);

            return request.Plot;
        }
    }
}
