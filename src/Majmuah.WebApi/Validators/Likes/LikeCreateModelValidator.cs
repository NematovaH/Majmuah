using FluentValidation;
using Majmuah.WebApi.Models.Likes;

namespace Majmuah.WebApi.Validators.Likes;

public class LikeCreateModelValidator : AbstractValidator<LikeCreateModel>
{
    public LikeCreateModelValidator()
    {
        RuleFor(x => x.ItemId)
            .GreaterThan(0)
            .WithMessage("Item ID must be greater than 0.");

        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithMessage("User ID must be greater than 0.");
    }
}