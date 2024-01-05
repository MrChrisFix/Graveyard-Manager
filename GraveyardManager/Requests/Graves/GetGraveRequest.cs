using GraveyardManager.Data;
using GraveyardManager.Exceptions;
using GraveyardManager.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GraveyardManager.Requests.Graves
{
    public record GetGraveRequest(int Id) : IRequest<Grave> { }

    public class GetGraveRequestHandler : IRequestHandler<GetGraveRequest, Grave>
    {
        readonly GraveyardDbContext _context;
        public GetGraveRequestHandler(GraveyardDbContext context)
        {
            _context = context;
        }

        public async Task<Grave> Handle(GetGraveRequest request, CancellationToken cancellationToken)
        {
            Grave response = await _context.Graves
                .Include(x => x.People)
                .FirstOrDefaultAsync(x => x.Id.Equals(request.Id), cancellationToken)
                ?? throw new NotFoundException($"The grave with the id {request.Id} was not found");

            return response;
        }
    }
}
