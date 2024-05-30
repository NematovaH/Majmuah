using FluentValidation;
using Majmuah.WebApi.Models.Tags;

namespace Majmuah.WebApi.Validators.Tags;

public class TagUpdateModelValidator : AbstractValidator<TagUpdateModel>
{
    public TagUpdateModelValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("Tag name is required.");
    }
}