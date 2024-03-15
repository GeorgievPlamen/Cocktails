using Cocktails.Application.Persistence.Contracts.Enums;
using MediatR;

namespace Cocktails.Application.CocktailsFeature.Queries.ListOfCockatilsByAlcohol
{
    public class ListByAlcoholRequest : IRequest<List<CocktailDTO>>
    {
        public AlcoholType AlcoholType { get; }
        public ListByAlcoholRequest(AlcoholType alcoholType)
        {
            AlcoholType = alcoholType;
        }
    }
}