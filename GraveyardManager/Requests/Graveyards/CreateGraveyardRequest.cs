using GraveyardManager.Data;
using GraveyardManager.Model;
using MediatR;

namespace GraveyardManager.Requests.Graveyards
{
    public record CreateGraveyardRequest(GraveyardOwner Owner, Address Address) : IRequest<Graveyard> { }

    public class CreateGraveyardRequestHandler : IRequestHandler<CreateGraveyardRequest, Graveyard>
    {
        readonly GraveDbContext _context;

        public CreateGraveyardRequestHandler(GraveDbContext context)
        {
            _context = context;
        }

        public async Task<Graveyard> Handle(CreateGraveyardRequest request, CancellationToken cancellationToken)
        {
            Graveyard graveyard = new(request.Owner, request.Address);
            
            await _context.Graveyards.AddAsync(graveyard, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return graveyard;
        }
    }
}
