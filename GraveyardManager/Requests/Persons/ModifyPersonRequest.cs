using GraveyardManager.Data;
using GraveyardManager.Exceptions;
using GraveyardManager.Model;
using GraveyardManager.Model.DTO;
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
            Person person = await _context.People.FindAsync(request.PersonDTO.Id, cancellationToken)
                ?? throw new NotFoundException($"Person with id {request.PersonDTO.Id} was not found");

            person.Update(request.PersonDTO);

            await _context.SaveChangesAsync(cancellationToken);

            return person;
        }
    }
}
