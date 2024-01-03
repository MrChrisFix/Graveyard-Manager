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

        public Task<Grave> Handle(AddPersonRequest request, CancellationToken cancellationToken)
        {
            Grave grave = _context.Graves
                .Include(x => x.People)
                .ToList()
                .Find(x=> x.Id == request.GraveId) ?? throw new NotFoundException("Grave not found");

            grave.People.Add(request.Person);

            _context.SaveChanges();

            return Task.FromResult(grave);
        }
    }
}
