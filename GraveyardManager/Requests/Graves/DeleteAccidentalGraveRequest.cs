using GraveyardManager.Data;
using GraveyardManager.Exceptions;
using GraveyardManager.Model;
using MediatR;

namespace GraveyardManager.Requests.Graves
{
    public record DeleteAccidentalGraveRequest(int Id) : IRequest<Unit>  { }

    public class DeleteAccidentalGraveRequestHandler : IRequestHandler<DeleteAccidentalGraveRequest, Unit>
    {
        readonly GraveyardDbContext _context;
        public DeleteAccidentalGraveRequestHandler(GraveyardDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteAccidentalGraveRequest request, CancellationToken cancellationToken)
        {
            Grave grave = await _context.Graves.FindAsync(request.Id) ?? throw new NotFoundException($"The grave with the id {request.Id} was not found");
            _context.Graves.Remove(grave);

            _context.SaveChanges();
            return Unit.Value;
        }
    }
}
