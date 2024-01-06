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
            Plot plot = await _context.Plots
                .Include(x => x.Grave)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException($"The plot with the id {request.Id} was not found");

            Graveyard graveyard = await _context.Graveyards
                .Include(x => x.Plots)
                .FirstOrDefaultAsync(x => x.Id == plot.GraveyardId, cancellationToken)
                ?? throw new Exception("Model error");

            plot.IsRemoved = true;

            if(plot.Grave is null && plot.RemovedGraves.Any() is false)
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
