using FluentValidation;
using Majmuah.Service.Helpers;
using Majmuah.WebApi.Models.Accounts;

namespace Majmuah.WebApi.Validators.Accounts;

public class SendCodeModelValidator : AbstractValidator<SendCodeModel>
{
    public SendCodeModelValidator()
    {

        RuleFor(sc => sc.Phone)
            .NotNull()
            .WithMessage(sc => $"{nameof(sc.Phone)} is not specified");

        RuleFor(sc => sc.Phone)
            .Must(ValidationHelper.IsPhoneValid);
    }
}