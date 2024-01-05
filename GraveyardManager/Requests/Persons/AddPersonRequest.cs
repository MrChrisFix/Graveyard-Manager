using GraveyardManager.Data;
using GraveyardManager.Exceptions;
using GraveyardManager.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GraveyardManager.Requests.Persons
{
    public record AddPersonRequest(int GraveId, Person Person) : IRequest<Grave> { }

    public class AddPersonRequestHandler : IRequestHandler<AddPersonRequest, Grave>
    {
        GraveyardDbContext _context;

        public AddPersonRequestHandler(GraveyardDbContext context)
        {
            _context = context;
        }

        public async Task<Grave> Handle(AddPersonRequest request, CancellationToken cancellationToken)
        {
            Grave grave = await _context.Graves
                .Include(x => x.People)
                .FirstOrDefaultAsync(x=> x.Id == request.GraveId, cancellationToken) 
                ?? throw new NotFoundException($"Grave with the id {request.GraveId} was not found");

            grave.People.Add(request.Person);

            await _context.SaveChangesAsync(cancellationToken);

            return grave;
        }
    }
}
