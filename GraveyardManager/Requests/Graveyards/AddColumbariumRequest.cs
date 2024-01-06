using GraveyardManager.Data;
using GraveyardManager.Exceptions;
using GraveyardManager.Model;
using MediatR;

/*namespace GraveyardManager.Requests.Graveyards
{
    public record AddColumbariumRequest(int Id, Columbarium Columbarium) : IRequest<Columbarium> { }

    public class AddColumbariumRequestHandler : IRequestHandler<AddColumbariumRequest, Columbarium>
    {
        GraveyardDbContext _context;

        public AddColumbariumRequestHandler(GraveyardDbContext context)
        {
            _context = context;
        }

        public async Task<Columbarium> Handle(AddColumbariumRequest request, CancellationToken cancellationToken)
        {
            var graveyard = await _context.Graveyards.FindAsync(request.Id, cancellationToken) 
                ?? throw new NotFoundException($"Graveyard with the id {request.Id} was not found");

            //TODO: here or frontend must check if the choosen place is free

            await _context.Columbaria.AddAsync(request.Columbarium, cancellationToken);

            graveyard.Columbaria.Add(request.Columbarium);

            await _context.SaveChangesAsync(cancellationToken);

            return request.Columbarium;
        }
    }
}*/
