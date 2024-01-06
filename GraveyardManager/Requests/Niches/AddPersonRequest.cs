using GraveyardManager.Data;
using GraveyardManager.Exceptions;
using GraveyardManager.Model;
using MediatR;

namespace GraveyardManager.Requests.Niches
{
    public record AddPersonRequest(int Id, Person Person) : IRequest<Niche> { }

    public class AddPersonRequestHandler : IRequestHandler<AddPersonRequest, Niche>
    {
        GraveyardDbContext _context;

        public AddPersonRequestHandler(GraveyardDbContext context)
        {
            _context = context;
        }

        public async Task<Niche> Handle(AddPersonRequest request, CancellationToken cancellationToken)
        {
            Niche niche = await _context.Niches.FindAsync(request.Id, cancellationToken)
                ?? throw new NotFoundException($"The niche with id {request.Id} was not found");

            niche.People.Add(request.Person);
            await _context.SaveChangesAsync(cancellationToken);

            return niche;
        }
    }
}
