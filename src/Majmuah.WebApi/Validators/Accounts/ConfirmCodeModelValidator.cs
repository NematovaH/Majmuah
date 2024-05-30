using FluentValidation;
using Majmuah.Service.Helpers;
using Majmuah.WebApi.Models.Accounts;

namespace Majmuah.WebApi.Validators.Accounts;

public class ConfirmCodeModelValidator : AbstractValidator<ConfirmCodeModel>
{
    public ConfirmCodeModelValidator()
    {
        RuleFor(cc => cc.Code)
            .NotNull()
            .WithMessage(cc => $"{nameof(cc.Code)} is not specified");

        RuleFor(cc => cc.Phone)
            .Must(ValidationHelper.IsPhoneValid);
    }
}
