using AutoMapper;
using Cocktails.Application.Persistence.Contracts;
using MediatR;

namespace Cocktails.Application.CocktailsFeature.Queries.ListOfCockatilsByAlcohol
{
    public class ListByAlcoholRequestHandler : IRequestHandler<ListByAlcoholRequest, List<CocktailDTO>>
    {
        private readonly ICocktailRepository _cocktailRepository;
        private readonly IMapper _mapper;
        public ListByAlcoholRequestHandler(ICocktailRepository cocktailRepository, IMapper mapper)
        {
            _mapper = mapper;
            _cocktailRepository = cocktailRepository;
        }
        public async Task<List<CocktailDTO>> Handle(ListByAlcoholRequest request, CancellationToken cancellationToken)
        {
            var cocktailsByAlcohol = await _cocktailRepository.GetAllByAlcoholAsync(request.AlcoholType);
            var result = _mapper.Map<List<CocktailDTO>>(cocktailsByAlcohol);
            return result;
        }
    }
}