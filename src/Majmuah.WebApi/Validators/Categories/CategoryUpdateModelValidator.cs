using FluentValidation;
using Majmuah.WebApi.Models.Categories;

namespace Majmuah.WebApi.Validators.Categories;

public class CategoryUpdateModelValidator : AbstractValidator<CategoryUpdateModel>
{
    public CategoryUpdateModelValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage(Category => $"{nameof(Category.Name)} is not specified");
    }
}