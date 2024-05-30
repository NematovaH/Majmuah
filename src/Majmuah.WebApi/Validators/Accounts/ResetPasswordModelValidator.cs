using FluentValidation;
using Majmuah.Service.Helpers;
using Majmuah.WebApi.Models.Accounts;

namespace Majmuah.WebApi.Validators.Accounts;

public class ResetPasswordModelValidator : AbstractValidator<ResetPasswordModel>
{
    public ResetPasswordModelValidator()
    {
        RuleFor(rp => rp.NewPassword)
            .NotNull()
            .WithMessage(rp => $"{nameof(rp.NewPassword)} is not specified");

        RuleFor(rp => rp.Phone)
            .NotNull()
            .WithMessage(rp => $"{nameof(rp.Phone)} is not specified");

        RuleFor(rp => rp.Phone)
            .Must(ValidationHelper.IsPhoneValid);

        RuleFor(rp => rp.NewPassword)
            .Must(ValidationHelper.IsPasswordHard);
    }
}