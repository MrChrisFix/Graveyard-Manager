using GraveyardManager.Data;
using GraveyardManager.Exceptions;
using GraveyardManager.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GraveyardManager.Requests.Persons
{
    public record ModifyPersonRequest(int GraveId, PersonDTO PersonDTO) : IRequest<Grave> { }

    public class ModifyPersonRequestHandler : IRequestHandler<ModifyPersonRequest, Grave>
    {
        GraveyardDbContext _context;

        public ModifyPersonRequestHandler(GraveyardDbContext context)
        {
            _context = context;
        }   

        public async Task<Grave> Handle(ModifyPersonRequest request, CancellationToken cancellationToken)
        {
            Grave grave = await _context.Graves
                .Include(x => x.People)
                .FirstOrDefaultAsync(x => x.Id == request.GraveId, cancellationToken) 
                ?? throw new NotFoundException("Grave not found");
            
            Person person = grave.People.Where(x => x.Id == request.PersonDTO.Id).First() 
                ?? throw new NotFoundException($"Person with id {request.PersonDTO.Id} was not found in grave");

            person.Update(request.PersonDTO);

            await _context.SaveChangesAsync(cancellationToken);

            return grave;
        }
    }
}
