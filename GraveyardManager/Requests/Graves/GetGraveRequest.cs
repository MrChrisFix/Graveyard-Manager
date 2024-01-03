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

        public Task<Grave> Handle(GetGraveRequest request, CancellationToken cancellationToken)
        {
            Grave response = _context.Graves
                .Include(x => x.People)
                .ToList()
                .Find(x => x.Id.Equals(request.Id)) ?? throw new NotFoundException($"The grave with the id {request.Id} was not found");

            return Task.FromResult(response);
        }
    }
}
