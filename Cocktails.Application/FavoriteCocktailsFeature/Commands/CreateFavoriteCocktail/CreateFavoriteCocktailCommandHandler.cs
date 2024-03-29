using AutoMapper;
using Cocktails.Application.Interfaces;
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
            if (request.Cocktail == null)
                return false;

            var favoriteCocktail = _mapper.Map<FavoriteCocktail>(request.Cocktail);
            favoriteCocktail.DateCreated = DateTime.UtcNow;

            return await _favoriteCocktailsRepository.AddAsync(favoriteCocktail);
        }
    }
}