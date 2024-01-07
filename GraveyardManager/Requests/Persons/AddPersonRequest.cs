using GraveyardManager.Data;
using GraveyardManager.Exceptions;
using GraveyardManager.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GraveyardManager.Requests.Persons
{
    public class AddPersonRequest : IRequest<Grave> 
    {
        public int GraveId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public DateOnly Birth { get; set; }

        public DateOnly Death { get; set; }

        public DateOnly? Ordained { get; set; }
        public DateTime? Funeral { get; set; }

    }

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

            Person person = new()
            { FirstName = request.FirstName,
                LastName = request.LastName,
                Birth = request.Birth,
                Death = request.Death,
                Ordained = request.Ordained,
                Funeral = request.Funeral,
                GraveId = request.GraveId,
                PlotId = grave.PlotId
            };

            grave.People.Add(person);

            await _context.SaveChangesAsync(cancellationToken);

            return grave;
        }
    }
}
