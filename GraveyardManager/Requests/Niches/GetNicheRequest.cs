using GraveyardManager.Data;
using GraveyardManager.Exceptions;
using GraveyardManager.Model;
using MediatR;

namespace GraveyardManager.Requests.Niches
{
    /*public record GetNicheRequest(int Id) : IRequest<Niche> { }

    public class GetNicheRequestHandler : IRequestHandler<GetNicheRequest, Niche>
    {
        GraveyardDbContext _context;
        public GetNicheRequestHandler(GraveyardDbContext context)
        {
            _context = context;
        }
        public async Task<Niche> Handle(GetNicheRequest request, CancellationToken cancellationToken)
        {
            Niche niche = await _context.Niches.FindAsync(request.Id, cancellationToken)
                ?? throw new NotFoundException($"The niche with id {request.Id} was not found");

            return niche;
        }
    }*/
}
