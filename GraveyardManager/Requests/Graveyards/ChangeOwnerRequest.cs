using GraveyardManager.Data;
using GraveyardManager.Exceptions;
using GraveyardManager.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GraveyardManager.Requests.Graveyards
{
    public record ChangeOwnerRequest(int Id, GraveyardOwner owner) : IRequest<Graveyard> { }

    public class ChangeOwnerRequestHandler : IRequestHandler<ChangeOwnerRequest, Graveyard>
    {
        GraveyardDbContext _context;

        public ChangeOwnerRequestHandler(GraveyardDbContext context)
        {
            _context = context;
        }

        public async Task<Graveyard> Handle(ChangeOwnerRequest request, CancellationToken cancellationToken)
        {
            Graveyard graveyard = await _context.Graveyards
                .Include(x=> x.Owner)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken) 
                ?? throw new NotFoundException($"Graveyard with the id {request.Id} was not found");

            if(graveyard.Owner.Id != request.owner.Id)
            {
                throw new BadRequestException("Owner id does not correspond to id in graveyard");
            }

            graveyard.Owner = request.owner;

            await _context.SaveChangesAsync(cancellationToken);

            return graveyard;
        }
    }
}
