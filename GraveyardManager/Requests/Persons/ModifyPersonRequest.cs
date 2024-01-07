using GraveyardManager.Data;
using GraveyardManager.Exceptions;
using GraveyardManager.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GraveyardManager.Requests.Persons
{
    public record ModifyPersonRequest(PersonDTO PersonDTO) : IRequest<Person> { }

    public class ModifyPersonRequestHandler : IRequestHandler<ModifyPersonRequest, Person>
    {
        GraveyardDbContext _context;

        public ModifyPersonRequestHandler(GraveyardDbContext context)
        {
            _context = context;
        }   

        public async Task<Person> Handle(ModifyPersonRequest request, CancellationToken cancellationToken)
        {
            /*Grave grave = await _context.Graves
                .Include(x => x.People)
                .FirstOrDefaultAsync(x => x.Id == request.GraveId, cancellationToken) 
                ?? throw new NotFoundException("Grave not found");*/
            
            Person person = await _context.People.FindAsync(request.PersonDTO.Id, cancellationToken)
                ?? throw new NotFoundException($"Person with id {request.PersonDTO.Id} was not found");

            person.Update(request.PersonDTO);

            await _context.SaveChangesAsync(cancellationToken);

            return person;
        }
    }
}
