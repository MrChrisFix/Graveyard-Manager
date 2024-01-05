using GraveyardManager.Data;
using GraveyardManager.Exceptions;
using GraveyardManager.Model;
using MediatR;

namespace GraveyardManager.Requests.Graves
{
    public record RemoveGraveRequest(int Id, DateOnly Removal) : IRequest<Unit> { }

    public class RemoveGraveRequestHandler : IRequestHandler<RemoveGraveRequest, Unit>
    {
        readonly GraveyardDbContext _context;
        public RemoveGraveRequestHandler(GraveyardDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoveGraveRequest request, CancellationToken cancellationToken)
        {
            Grave grave = await _context.Graves.FindAsync(request.Id) ?? throw new NotFoundException($"The grave with the id {request.Id} was not found");
            RemovedGrave removedGrave = new(grave, request.Removal);

            await _context.RemovedGraves.AddAsync(removedGrave, cancellationToken);
            _context.Plots.Find(grave.Plot.Id)!.Grave = null;

            _context.Graves.Remove(grave);

            _context.SaveChanges();

            return Unit.Value;
        }
    }
}
