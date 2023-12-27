using GraveyardManager.Data;
using GraveyardManager.Exceptions;
using GraveyardManager.Model;
using MediatR;

namespace GraveyardManager.Requests.Graves
{
    public record RemoveGraveRequest(int Id, DateOnly Removal) : IRequest<Unit> { }

    public class RemoveGraveRequestHandler : IRequestHandler<RemoveGraveRequest, Unit>
    {
        readonly GraveDbContext _context;
        public RemoveGraveRequestHandler(GraveDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoveGraveRequest request, CancellationToken cancellationToken)
        {
            Grave grave = await _context.Graves.FindAsync(request.Id) ?? throw new NotFoundException($"The grave with the id {request.Id} was not found");
            RemovedGrave removedGrave = new(grave, request.Removal);

            await _context.RemovedGraves.AddAsync(removedGrave);
            _context.Plots.Find(grave.UsedPlotId)!.Grave = null;

            _context.Graves.Remove(grave);

            _context.SaveChanges();

            return Unit.Value;
        }
    }
}
