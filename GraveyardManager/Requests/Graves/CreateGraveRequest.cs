using GraveyardManager.Model;
using GraveyardManager.Exceptions;
using MediatR;
using GraveyardManager.Data;
using Microsoft.EntityFrameworkCore;

namespace GraveyardManager.Requests.Graves
{
    public record CreateGraveRequest(int PlotId, DateOnly PlotAcquisition, DateOnly PaidUntil) : IRequest<Grave> { }

    public class CreateGraveReqiestHandler : IRequestHandler<CreateGraveRequest, Grave>
    {
        readonly GraveyardDbContext _context;
        public CreateGraveReqiestHandler(GraveyardDbContext context)
        {
            _context = context;
        }

        public async Task<Grave> Handle(CreateGraveRequest request, CancellationToken cancellationToken)
        {
            Plot plot = await _context.Plots
                .Include(x=> x.Grave)
                .ThenInclude(x => x!.People)
                .FirstOrDefaultAsync(x => x.Id == request.PlotId, cancellationToken)
                ?? throw new NotFoundException($"Plot with the id {request.PlotId} was not found");

            if(plot.Grave != null)
            {
                throw new BadRequestException("Plot is not empty");
            }

            Grave grave = new()
            {
                PaidUntil = request.PaidUntil,
                PlotAcquisition = request.PlotAcquisition,
                PlotId = request.PlotId
            };

            await _context.Graves.AddAsync(grave, cancellationToken);
            plot.Grave = grave;

            await _context.SaveChangesAsync(cancellationToken);

            return grave;
        }
    }
}
