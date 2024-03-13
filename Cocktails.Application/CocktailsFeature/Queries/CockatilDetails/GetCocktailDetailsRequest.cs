using MediatR;

namespace Cocktails.Application.CocktailsFeature.Queries.CockatilDetails
{
    public class GetCocktailDetailsRequest : IRequest<CocktailDetailsDTO>
    {
        public int Id { get; }

        public GetCocktailDetailsRequest(int id)
        {
            Id = id;
        }
    }
}