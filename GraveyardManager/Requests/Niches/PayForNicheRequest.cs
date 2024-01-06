using GraveyardManager.Data;
using GraveyardManager.Exceptions;
using GraveyardManager.Model;
using MediatR;

namespace GraveyardManager.Controllers
{
    /*public record PayForNicheRequest(int Id, DateOnly PaidUntil) : IRequest<Niche> { }

    public class PayForNicheRequestHandler : IRequestHandler<PayForNicheRequest, Niche>
    {
        GraveyardDbContext _context;
        public PayForNicheRequestHandler(GraveyardDbContext context)
        {
            _context = context;
        }

        public async Task<Niche> Handle(PayForNicheRequest request, CancellationToken cancellationToken)
        {
            Niche niche = await _context.Niches.FindAsync(request.Id, cancellationToken)
                ?? throw new NotFoundException($"Niche with the id {request.Id} was not found");

            if (niche.PaidUntil > request.PaidUntil)
            {
                throw new BadRequestException("The new date cannot be earlier than the older");
            }

            niche.PaidUntil = request.PaidUntil;

            await _context.SaveChangesAsync(cancellationToken);

            return niche;
        }
    }*/
}