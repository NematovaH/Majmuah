﻿using FluentValidation;
using Majmuah.WebApi.Models.RolePermissions;

namespace Majmuah.WebApi.Validators.RolePermissions;

public class RolePermissionCreateModelValidator : AbstractValidator<RolePermissionCreateModel>
{
    public RolePermissionCreateModelValidator()
    {
        RuleFor(rolePermission => rolePermission.RoleId)
            .NotNull()
            .WithMessage(rolePermission => $"{nameof(rolePermission.RoleId)} is not specified");

        RuleFor(rolePermission => rolePermission.PermissionId)
            .NotNull()
            .WithMessage(rolePermission => $"{nameof(rolePermission.PermissionId)} is not specified");
    }
}