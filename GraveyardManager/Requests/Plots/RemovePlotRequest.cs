using GraveyardManager.Data;
using GraveyardManager.Exceptions;
using GraveyardManager.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GraveyardManager.Requests.Plots
{
    public record RemovePlotRequest(int Id, DateOnly Removal) : IRequest { }

    public class RemovePlotRequestHandler : IRequestHandler<RemovePlotRequest>
    {
        GraveyardDbContext _context;

        public RemovePlotRequestHandler(GraveyardDbContext context)
        {
            _context = context;
        }

        public async Task Handle(RemovePlotRequest request, CancellationToken cancellationToken)
        {
            var plot = await _context.Plots
                .Include(x => x.Graveyard)
                .FirstOrDefaultAsync(x => x.Id == request.Id)
                ?? throw new NotFoundException($"The plot with the id {request.Id} was not found");

            plot.IsRemoved = plot.Graveyard.Plots.Remove(plot);

            if (plot.IsRemoved is false)
                throw new Exception("Couldn't remove the plot");

            if(plot.Grave is not null && plot.RemovedGraves.Any() is false)
            { //Hard remove
                _context.Plots.Remove(plot);
            }
            else if(plot.Grave is not null)
            { //Soft remove
                RemovedGrave removedGrave = new(plot.Grave, request.Removal);
                await _context.RemovedGraves.AddAsync(removedGrave, cancellationToken);

                plot.RemovedGraves.Add(removedGrave);
                _context.Graves.Remove(plot.Grave);
                plot.Grave = null;
            }



            await _context.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
