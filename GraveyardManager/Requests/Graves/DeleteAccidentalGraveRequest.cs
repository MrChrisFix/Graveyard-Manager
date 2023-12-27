using GraveyardManager.Data;
using GraveyardManager.Exceptions;
using GraveyardManager.Model;
using MediatR;

namespace GraveyardManager.Requests.Graves
{
    public record DeleteAccidentalGraveRequest(int Id) : IRequest<Unit>  { }

    public class DeleteAccidentalGraveRequestHandler : IRequestHandler<DeleteAccidentalGraveRequest, Unit>
    {
        readonly GraveDbContext _context;
        public DeleteAccidentalGraveRequestHandler(GraveDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteAccidentalGraveRequest request, CancellationToken cancellationToken)
        {
            Grave grave = await _context.Graves.FindAsync(request.Id) ?? throw new NotFoundException($"Grave with id {request.Id} not found");
            _context.Graves.Remove(grave);

            _context.SaveChanges();
            return Unit.Value;
        }
    }
}
