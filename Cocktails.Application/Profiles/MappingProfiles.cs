using AutoMapper;
using Cocktails.Application.CocktailsFeature;
using Cocktails.Application.Common;
using Cocktails.Application.FavoriteCocktailsFeature;
using Cocktails.Domain;

namespace Cocktails.Application.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Cocktail, CocktailDTO>().ReverseMap();
            CreateMap<CocktailDetails, CocktailDetailsDTO>().ReverseMap();
            CreateMap<FavoriteCocktail, FavoriteCocktailDTO>().ReverseMap();
        }
    }
}