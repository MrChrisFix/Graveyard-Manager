using GraveyardManager.Data;
using GraveyardManager.Exceptions;
using GraveyardManager.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GraveyardManager.Requests.Persons
{
    public record ModifyPersonRequest(int GraveId, PersonDTO personDTO) : IRequest<Grave> { }

    public class ModifyPersonRequestHandler : IRequestHandler<ModifyPersonRequest, Grave>
    {
        GraveDbContext _context;

        public ModifyPersonRequestHandler(GraveDbContext context)
        {
            _context = context;
        }   

        public Task<Grave> Handle(ModifyPersonRequest request, CancellationToken cancellationToken)
        {
            Grave grave = _context.Graves
                .Include(x => x.Persons)
                .ToList()
                .Find(x => x.Id == request.GraveId) ?? throw new NotFoundException("Grave not found");

            Person person = grave.Persons.Where(x => x.Id == request.personDTO.Id).First() ?? throw new NotFoundException("Person not found in grave");
            person.Update(request.personDTO);

            _context.SaveChanges();

            return Task.FromResult(grave);
        }
    }
}
