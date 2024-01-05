using GraveyardManager.Data;
using GraveyardManager.Exceptions;
using GraveyardManager.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GraveyardManager.Requests.Graveyards
{
    public record GetGraveyardRequest(int Id) : IRequest<Graveyard> { }

    public class GetGraveyardRequestHandler : IRequestHandler<GetGraveyardRequest, Graveyard>
    {
        readonly GraveyardDbContext _context;

        public GetGraveyardRequestHandler(GraveyardDbContext context)
        {
            _context = context;
        }

        public async Task<Graveyard> Handle(GetGraveyardRequest request, CancellationToken cancellationToken)
        {
            Graveyard graveyard = await _context.Graveyards
                .Include(x => x.Plots)
                .Include(x => x.Columbaria).FirstOrDefaultAsync(x => x.Id == request.Id) 
                ?? throw new NotFoundException($"Graveyard with the id {request.Id} was not found");
            return graveyard;
        }
    }
}
