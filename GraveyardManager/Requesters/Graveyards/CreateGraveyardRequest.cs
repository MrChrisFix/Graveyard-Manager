using GraveyardManager.Data;
using GraveyardManager.Model;
using MediatR;

namespace GraveyardManager.Requesters.Graveyards
{
    //TODO
    public record CreateGraveyardRequest() : IRequest<Graveyard> { }

    public class CreateGraveyardRequestHandler : IRequestHandler<CreateGraveyardRequest, Graveyard>
    {
        GraveDbContext _context;

        public CreateGraveyardRequestHandler(GraveDbContext context)
        {
            _context = context;
        }

        public Task<Graveyard> Handle(CreateGraveyardRequest request, CancellationToken cancellationToken)
        {
            Graveyard graveyard = new();
            
            _context.Graveyards.Add(graveyard);
            _context.SaveChanges();

            return Task.FromResult(graveyard);
        }
    }
}
