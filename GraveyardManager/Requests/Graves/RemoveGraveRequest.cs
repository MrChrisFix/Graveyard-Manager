using GraveyardManager.Data;
using GraveyardManager.Exceptions;
using GraveyardManager.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GraveyardManager.Requests.Graves
{
    public record RemoveGraveRequest(int Id, DateOnly Removal) : IRequest { }

    public class RemoveGraveRequestHandler : IRequestHandler<RemoveGraveRequest>
    {
        readonly GraveyardDbContext _context;
        public RemoveGraveRequestHandler(GraveyardDbContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveGraveRequest request, CancellationToken cancellationToken)
        {
            Grave grave = await _context.Graves
                .Include(x => x.People)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException($"The grave with the id {request.Id} was not found");
            RemovedGrave removedGrave = new(grave, request.Removal);

            _context.RemovedGraves.Add(removedGrave);

            Plot plot = _context.Plots.Find(grave.PlotId)!;

            plot.RemovedGraves.Add(removedGrave);
            plot.Grave = null;

            _context.Graves.Remove(grave);

            await _context.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
