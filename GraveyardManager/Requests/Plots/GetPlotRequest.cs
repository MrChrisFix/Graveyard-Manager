using GraveyardManager.Data;
using GraveyardManager.Exceptions;
using GraveyardManager.Model;
using MediatR;

namespace GraveyardManager.Requests.Plots
{
    public record GetPlotRequest(int Id) : IRequest<Plot> { }

    public class GetPlotRequestHandler : IRequestHandler<GetPlotRequest, Plot>
    {
        GraveyardDbContext _context;
        public GetPlotRequestHandler(GraveyardDbContext context)
        {
            _context = context;
        }

        public async Task<Plot> Handle(GetPlotRequest request, CancellationToken cancellationToken)
        {
            var plot = await _context.Plots.FindAsync(request.Id, cancellationToken)
                ?? throw new NotFoundException($"The plot with the id {request.Id} was not found");

            return plot;
        }
    }
}
