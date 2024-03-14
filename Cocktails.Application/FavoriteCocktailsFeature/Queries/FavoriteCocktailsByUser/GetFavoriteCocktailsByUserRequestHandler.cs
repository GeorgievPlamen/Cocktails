using AutoMapper;
using Cocktails.Application.Persistence.Contracts;
using MediatR;

namespace Cocktails.Application.FavoriteCocktailsFeature.Queries.FavoriteCocktailsByUser
{
    public class GetFavoriteCocktailsByUserRequestHandler
        : IRequestHandler<GetFavoriteCocktailsByUserRequest,
        List<FavoriteCocktailDTO>>
    {
        private readonly IFavoriteCocktailsRepository _favoriteCocktailsRepository;
        private readonly IMapper _mapper;
        public GetFavoriteCocktailsByUserRequestHandler(
            IFavoriteCocktailsRepository favoriteCocktailsRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _favoriteCocktailsRepository = favoriteCocktailsRepository;

        }
        public async Task<List<FavoriteCocktailDTO>> Handle(
            GetFavoriteCocktailsByUserRequest request,
            CancellationToken cancellationToken)
        {
            if (request.UserId == null)
                throw new ArgumentNullException(nameof(request.UserId));

            var favoriteCocktails = await _favoriteCocktailsRepository
                .GetAllByUser(request.UserId);

            return _mapper.Map<List<FavoriteCocktailDTO>>(favoriteCocktails);
        }
    }
}