using FluentValidation;
using Majmuah.WebApi.Models.Categories;

namespace Majmuah.WebApi.Validators.Categories;

public class CategoryCreateModelValidator : AbstractValidator<CategoryCreateModel>
{
    public CategoryCreateModelValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage(Category => $"{nameof(Category.Name)} is not specified");
    }
}