using GraveyardManager.Data;
using GraveyardManager.Model;
using MediatR;

namespace GraveyardManager.Requests.Graveyards
{
    public record CreateGraveyardRequest(GraveyardOwner Owner, Address Address) : IRequest<Graveyard> { }

    public class CreateGraveyardRequestHandler : IRequestHandler<CreateGraveyardRequest, Graveyard>
    {
        readonly GraveyardDbContext _context;

        public CreateGraveyardRequestHandler(GraveyardDbContext context)
        {
            _context = context;
        }

        public async Task<Graveyard> Handle(CreateGraveyardRequest request, CancellationToken cancellationToken)
        {
            Graveyard graveyard = new(request.Owner, request.Address);
            
            _context.Graveyards.Add(graveyard);
            await _context.SaveChangesAsync(cancellationToken);

            return graveyard;
        }
    }
}
