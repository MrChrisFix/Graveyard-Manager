using GraveyardManager.Exceptions;
using GraveyardManager.Model;
using MediatR;

namespace GraveyardManager.Requests.Persons
{
    public class SearchPersonRequest : IRequest<IEnumerable<SearchResult>> 
    {
        public readonly string? FirstName;
        public readonly string? LastName;
        public readonly DateOnly? Birth;
        public readonly DateOnly? Death;

        public SearchPersonRequest(
            string firstName, string lastName,
            DateOnly? birth, DateOnly? death            
            ) 
        {
            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
                throw new BadRequestException("First name or last name must have value");
            FirstName = firstName;
            LastName = lastName;
            Birth = birth;
            Death = death;
        }
    }

    public class SearchPersonRequestHandler : IRequestHandler<SearchPersonRequest, IEnumerable<SearchResult>>
    {

        public Task<IEnumerable<SearchResult>> Handle(SearchPersonRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }


    public class SearchResult
    {
        public Graveyard Graveyard { get; set; }
        //TOOO: Where on the graveyard
        public Person Person { get; set; }

    }
}
