using GraveyardManager.Data;
using GraveyardManager.Exceptions;
using GraveyardManager.Model;
using MediatR;

namespace GraveyardManager.Requests.Graves
{
    public record DeleteAccidentalGraveRequest(int Id) : IRequest { }

    public class DeleteAccidentalGraveRequestHandler : IRequestHandler<DeleteAccidentalGraveRequest>
    {
        readonly GraveyardDbContext _context;
        public DeleteAccidentalGraveRequestHandler(GraveyardDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteAccidentalGraveRequest request, CancellationToken cancellationToken)
        {
            Grave grave = await _context.Graves.FindAsync(request.Id, cancellationToken)
                ?? throw new NotFoundException($"The grave with the id {request.Id} was not found");
            _context.Graves.Remove(grave);

            await _context.SaveChangesAsync(cancellationToken);
            return;
        }
    }
}
