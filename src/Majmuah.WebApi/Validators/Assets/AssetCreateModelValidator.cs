using FluentValidation;
using Majmuah.WebApi.Models.Assets;

namespace Majmuah.WebApi.Validators.Assets;

public class AssetCreateModelValidator : AbstractValidator<AssetCreateModel>
{
    public AssetCreateModelValidator()
    {
        RuleFor(asset => asset.FileType)
            .NotNull()
            .IsInEnum()
            .WithMessage(asset => $"{nameof(asset.FileType)} is not specified");

        RuleFor(asset => asset.File)
            .NotNull()
            .WithMessage(asset => $"{nameof(asset.FileType)} is not specified");
    }
}