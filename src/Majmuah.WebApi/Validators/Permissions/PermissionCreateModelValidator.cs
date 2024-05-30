using FluentValidation;
using Majmuah.WebApi.Models.Permissions;

namespace Majmuah.WebApi.Validators.Permissions;

public class PermissionCreateModelValidator : AbstractValidator<PermissionCreateModel>
{
    public PermissionCreateModelValidator()
    {
        RuleFor(permission => permission.Action)
            .NotNull()
            .WithMessage(permission => $"{nameof(permission.Action)} is not specified");

        RuleFor(permission => permission.Controller)
            .NotNull()
            .WithMessage(permission => $"{nameof(permission.Controller)} is not specified");
    }
}