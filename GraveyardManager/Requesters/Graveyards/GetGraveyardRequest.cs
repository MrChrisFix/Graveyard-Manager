using GraveyardManager.Data;
using GraveyardManager.Exceptions;
using GraveyardManager.Model;
using MediatR;

namespace GraveyardManager.Requesters.Graveyards
{
    public record GetGraveyardRequest(int Id) : IRequest<Graveyard> { }

    public class GetGraveyardRequestHandler : IRequestHandler<GetGraveyardRequest, Graveyard>
    {
        GraveDbContext _context;

        public GetGraveyardRequestHandler(GraveDbContext context)
        {
            _context = context;
        }

        public Task<Graveyard> Handle(GetGraveyardRequest request, CancellationToken cancellationToken)
        {
            Graveyard graveyard = _context.Graveyards.Find(request.Id, cancellationToken) ?? throw new NotFoundException("Graveyard not found");

            return Task.FromResult(graveyard);
        }
    }
}
