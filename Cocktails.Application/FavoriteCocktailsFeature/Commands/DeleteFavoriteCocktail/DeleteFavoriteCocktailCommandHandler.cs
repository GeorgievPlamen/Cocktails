using AutoMapper;
using Cocktails.Application.Persistence.Contracts;
using MediatR;

namespace Cocktails.Application.FavoriteCocktailsFeature.Commands.DeleteFavoriteCocktail
{
    public class DeleteFavoriteCocktailCommandHandler
        : IRequestHandler<DeleteFavoriteCocktailCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IFavoriteCocktailsRepository _favoriteCocktailsRepository;
        public DeleteFavoriteCocktailCommandHandler(
            IFavoriteCocktailsRepository favoriteCocktailsRepository,
            IMapper mapper)
        {
            _favoriteCocktailsRepository = favoriteCocktailsRepository;
            _mapper = mapper;

        }
        public async Task<bool> Handle(DeleteFavoriteCocktailCommand request, CancellationToken cancellationToken)
        {
            var cocktail = await _favoriteCocktailsRepository.GetAsync(request.Id);
            return await _favoriteCocktailsRepository.DeleteAsync(cocktail);
        }
    }
}