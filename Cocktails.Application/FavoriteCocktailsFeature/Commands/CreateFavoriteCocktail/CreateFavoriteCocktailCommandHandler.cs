using AutoMapper;
using Cocktails.Application.Persistence.Contracts;
using Cocktails.Domain;
using MediatR;

namespace Cocktails.Application.FavoriteCocktailsFeature.Commands.CreateFavoriteCocktail
{
    public class CreateFavoriteCocktailCommandHandler
        : IRequestHandler<CreateFavoriteCocktailCommand, bool>
    {
        private readonly IFavoriteCocktailsRepository _favoriteCocktailsRepository;
        private readonly IMapper _mapper;
        public CreateFavoriteCocktailCommandHandler(
            IFavoriteCocktailsRepository favoriteCocktailsRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _favoriteCocktailsRepository = favoriteCocktailsRepository;
        }
        public async Task<bool> Handle(CreateFavoriteCocktailCommand request, CancellationToken cancellationToken)
        {
            var favoriteCocktail = _mapper.Map<FavoriteCocktail>(request.Cocktail);

            return await _favoriteCocktailsRepository.Add(favoriteCocktail);
        }
    }
}