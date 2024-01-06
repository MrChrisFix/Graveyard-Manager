using GraveyardManager.Data;
using GraveyardManager.Exceptions;
using GraveyardManager.Model;
using MediatR;

namespace GraveyardManager.Requests.Niches
{
    public record ClearNicheRequest(int Id) : IRequest<Niche> { }

    public class ClearNicheRequestHandler : IRequestHandler<ClearNicheRequest, Niche>
    {
        GraveyardDbContext _context;
        public ClearNicheRequestHandler(GraveyardDbContext context)
        {
            _context = context;
        }
        public async Task<Niche> Handle(ClearNicheRequest request, CancellationToken cancellationToken)
        {
            Niche niche = await _context.Niches.FindAsync(request.Id, cancellationToken)
                ?? throw new NotFoundException($"The niche with id {request.Id} was not found");

            foreach(var person in niche.People)
            {
                niche.RemovedPeople.Add(person);
            }
            niche.People.Clear();
            await _context.SaveChangesAsync(cancellationToken);

            return niche;
        }
    }
}
