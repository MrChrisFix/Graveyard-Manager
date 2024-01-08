using GraveyardManager.Data;
using GraveyardManager.Model;
using GraveyardManager.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GraveyardManager.Requests.Plots
{
    public class AddPlotRequest : IRequest<Plot>
    {
        public Plot.PlotSize Size { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Angle { get; set; }
        public string? GraveyardPart { get; set; }
        public int GraveyardId { get; set; }

        public Plot CreatePlot()
        {
            Plot plot = new()
            {
                Size = Size,
                X = X,
                Y = Y,
                Angle = Angle,
                GraveyardPart = GraveyardPart,
                GraveyardId = GraveyardId
            };
            return plot;
        }
    }

    public class AddPlotRequestHandler : IRequestHandler<AddPlotRequest, Plot>
    {
        GraveyardDbContext _context;

        public AddPlotRequestHandler(GraveyardDbContext context)
        {
            _context = context;
        }

        public async Task<Plot> Handle(AddPlotRequest request, CancellationToken cancellationToken)
        {
            Graveyard graveyard = await _context.Graveyards
                .Include(x => x.Plots)
                .FirstOrDefaultAsync(x => x.Id == request.GraveyardId, cancellationToken)
                ?? throw new NotFoundException($"Graveyard with the id {request.GraveyardId} was not found");

            Plot plot = request.CreatePlot();

            _context.Plots.Add(plot);

            graveyard.Plots.Add(plot);

            await _context.SaveChangesAsync(cancellationToken);

            return plot;
        }
    }
}
