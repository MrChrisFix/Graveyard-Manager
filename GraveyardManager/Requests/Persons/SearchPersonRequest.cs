using GraveyardManager.Data;
using GraveyardManager.Exceptions;
using GraveyardManager.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GraveyardManager.Requests.Persons
{
    public record SearchPersonRequest(string? FirstName, string? LastName, DateOnly? DateFrom, DateOnly? DateTo) : IRequest<IList<SearchResult>> { }

    public class SearchPersonRequestHandler : IRequestHandler<SearchPersonRequest, IList<SearchResult>>
    {
        GraveyardDbContext _context;

        public SearchPersonRequestHandler(GraveyardDbContext context)
        {
            _context = context;
        }

        public async Task<IList<SearchResult>> Handle(SearchPersonRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.FirstName) && string.IsNullOrEmpty(request.LastName))
                throw new BadRequestException("First name or last name must have value");

            var findings = _context.People.AsQueryable();
            
            if(!string.IsNullOrEmpty(request.FirstName))
            {
                findings = findings.Where(x => x.FirstName == request.FirstName);
            }

            if (!string.IsNullOrEmpty(request.LastName))
            {
                findings = findings.Where(x => x.LastName == request.LastName);
            }

            if (!(request.DateFrom == null || request.DateFrom == default))
            {
                findings = findings.Where(x => x.Birth >= request.DateFrom);
            }

            if (!(request.DateTo == null || request.DateTo == default))
            {
                findings = findings.Where(x => x.Death <= request.DateTo);
            }

            await findings.ToListAsync(cancellationToken);

            var test = _context.People.ToList();

            IList<SearchResult> results = new List<SearchResult>();

            foreach(var person in findings)
            {
                Plot? plot = await _context.Plots
                    .AsNoTracking()
                    .Include(x=> x.Grave)
                    .ThenInclude(x => x!.People)
                    .FirstOrDefaultAsync(x => x.Id == person.PlotId, cancellationToken);
                if(plot == null)
                    continue;

                Graveyard? graveyard = await _context.Graveyards
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x=> x.Id == plot.GraveyardId, cancellationToken);
                if (graveyard == null)
                    continue;

                SearchResult res = new()
                {
                    Person = person,
                    Plot = plot,
                    Graveyard = graveyard,
                    IsStillThere = plot.Grave != null && plot.Grave.People.Any(x => x.Id == person.Id)
                };
                results.Add(res);
            }
            
            return results;
        }
    }

    public class SearchResult
    {
        public required Graveyard Graveyard { get; set; }
        public required Plot Plot { get; set; }
        public required Person Person { get; set; }
        public bool IsStillThere { get; set; }
    }
}
