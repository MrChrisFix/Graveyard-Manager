using GraveyardManager.Data;
using GraveyardManager.Exceptions;
using GraveyardManager.Model;
using MediatR;

namespace GraveyardManager.Requests.Graves
{
    public record PayForGraveRequest(int Id, DateOnly PaidUntil) : IRequest<Grave> { }
    public class PayForGraveRequestHandler : IRequestHandler<PayForGraveRequest, Grave>
    {
        GraveyardDbContext _context;

        public PayForGraveRequestHandler(GraveyardDbContext context)
        {
            _context = context;
        }

        public async Task<Grave> Handle(PayForGraveRequest request, CancellationToken cancellationToken)
        {
            Grave grave = await _context.Graves.FindAsync(request.Id, cancellationToken)
                ?? throw new NotFoundException($"Grave with the id {request.Id} was not found");

            if(grave.PaidUntil > request.PaidUntil)
            {
                throw new BadRequestException("The new date cannot be earlier than the older");
            }

            grave.PaidUntil = request.PaidUntil;

            await _context.SaveChangesAsync(cancellationToken);

            return grave;
        }
    }

}
