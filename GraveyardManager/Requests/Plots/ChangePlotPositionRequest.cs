using GraveyardManager.Data;
using GraveyardManager.Exceptions;
using GraveyardManager.Model;
using GraveyardManager.Model.DTO;
using MediatR;

namespace GraveyardManager.Requests.Plots
{
    public record ChangePlotPositionRequest(int Id, ChangePositionDTO DTO) : IRequest<Plot> { }

    public class ChangePlotPositionRequestHandler : IRequestHandler<ChangePlotPositionRequest, Plot>
    {
        GraveyardDbContext _context;
        public ChangePlotPositionRequestHandler(GraveyardDbContext context)
        {
            _context = context;
        }

        public async Task<Plot> Handle(ChangePlotPositionRequest request, CancellationToken cancellationToken)
        {
            Plot plot = await _context.Plots.FindAsync(request.Id, cancellationToken) 
                ?? throw new NotFoundException($"Plot with the id {request.Id} was not found");

            if(request.DTO.Part != null)
                plot.GraveyardPart = request.DTO.Part;

            if (request.DTO.Angle != null)
                plot.Angle = (decimal)request.DTO.Angle;

            if(request.DTO.X != null)
                plot.X = (decimal)request.DTO.X;

            if(request.DTO.Y != null)
                plot.Y = (decimal)request.DTO.Y;

            await _context.SaveChangesAsync(cancellationToken);

            return plot;
        }
    }
}
