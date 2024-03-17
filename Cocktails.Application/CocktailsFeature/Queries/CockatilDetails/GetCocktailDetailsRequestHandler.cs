using AutoMapper;
using Cocktails.Application.Interfaces;
using MediatR;

namespace Cocktails.Application.CocktailsFeature.Queries.CockatilDetails
{
    public class GetCocktailDetailsRequestHandler
        : IRequestHandler<GetCocktailDetailsRequest, CocktailDetailsDTO>
    {
        private readonly ICocktailRepository _cocktailsRepository;
        private readonly IMapper _mapper;

        public GetCocktailDetailsRequestHandler(
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
            var cocktail = await _cocktailsRepository.GetAsync(request.Id);

            return _mapper.Map<CocktailDetailsDTO>(cocktail);
        }
    }
}