using AutoMapper;
using Cocktails.Application.Persistence.Contracts;
using MediatR;

namespace Cocktails.Application.CocktailsFeature.Queries.CockatilDetails
{
    public class GetCocktailDetailsHandler : IRequestHandler<GetCocktailDetailsRequest, CocktailDetailsDTO>
    {
        private readonly ICocktailRepository _cocktailsRepository;
        private readonly IMapper _mapper;

        public GetCocktailDetailsHandler(
            ICocktailRepository cocktailsRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _cocktailsRepository = cocktailsRepository;
        }
        public async Task<CocktailDetailsDTO> Handle(
            GetCocktailDetailsRequest request,
            CancellationToken cancellationToken)
        {
            var cocktail = await _cocktailsRepository.Get(request.Id);

            
            return _mapper.Map<CocktailDetailsDTO>(cocktail);
        }
    }
}