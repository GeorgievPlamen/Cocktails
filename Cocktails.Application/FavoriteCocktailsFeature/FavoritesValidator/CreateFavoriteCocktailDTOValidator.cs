using FluentValidation;

namespace Cocktails.Application.FavoriteCocktailsFeature.FavoritesValidator
{
    public class CreateFavoriteCocktailDTOValidator : AbstractValidator<CreateFavoriteCocktailDTO>
    {
        public CreateFavoriteCocktailDTOValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} cannot be null")
                .Length(3, 50).WithMessage("{PropertyName} has to be between 3 and 50 charecters long.");
        }
    }
}