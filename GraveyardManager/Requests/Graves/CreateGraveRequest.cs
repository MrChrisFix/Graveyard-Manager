using GraveyardManager.Model;
using GraveyardManager.Exceptions;
using MediatR;
using GraveyardManager.Data;

namespace GraveyardManager.Requests.Graves
{
    public record CreateGraveRequest(Grave NewGrave) : IRequest<Grave> { }

    public class CreateGraveReqiestHandler : IRequestHandler<CreateGraveRequest, Grave>
    {
        readonly GraveDbContext _context;
        public CreateGraveReqiestHandler(GraveDbContext context)
        {
            _context = context;
        }

        public Task<Grave> Handle(CreateGraveRequest request, CancellationToken cancellationToken)
        {
            /*Plot plot = _context.Plots.Find(request.NewGrave.UsedPlotId) ?? throw new Exception("Plot not found"); //TODO: other exception

            if(plot.Grave != null)
            {
                throw new Exception("Plot is not free"); //TODO: a different exception
            }*/

            _context.Graves.Add(request.NewGrave);
            //plot.Grave = request.NewGrave;

            _context.SaveChanges();

            //TODO: get the added Grave; Problem: where to get it's id? ===> Check with ram Db and postman

            Grave addedGrave = _context.Graves.Find(request.NewGrave.Id)!;

            return Task.FromResult(addedGrave);
        }
    }
}
