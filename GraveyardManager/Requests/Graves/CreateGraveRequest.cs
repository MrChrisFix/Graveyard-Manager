using GraveyardManager.Model;
using GraveyardManager.Exceptions;
using MediatR;
using GraveyardManager.Data;

namespace GraveyardManager.Requests.Graves
{
    public record CreateGraveRequest(Grave Grave) : IRequest<Grave> { }

    public class CreateGraveReqiestHandler : IRequestHandler<CreateGraveRequest, Grave>
    {
        readonly GraveyardDbContext _context;
        public CreateGraveReqiestHandler(GraveyardDbContext context)
        {
            _context = context;
        }

        public async Task<Grave> Handle(CreateGraveRequest request, CancellationToken cancellationToken)
        {
            Plot plot = await _context.Plots.FindAsync(request.Grave.PlotId, cancellationToken)
                ?? throw new NotFoundException($"Plot with the id {request.Grave.PlotId} was not found");

            if(plot.Grave != null)
            {
                throw new BadRequestException("Plot is not empty");
            }

            await _context.Graves.AddAsync(request.Grave, cancellationToken);
            plot.Grave = request.Grave;

            await _context.SaveChangesAsync(cancellationToken);

            return request.Grave;
        }
    }
}
