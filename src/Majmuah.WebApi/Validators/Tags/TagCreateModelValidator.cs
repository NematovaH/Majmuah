using FluentValidation;
using Majmuah.WebApi.Models.Tags;

namespace Majmuah.WebApi.Validators.Tags;

public class TagCreateModelValidator : AbstractValidator<TagCreateModel>
{
    public TagCreateModelValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("Tag name is required.");
    }
}
