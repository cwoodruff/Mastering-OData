using FluentValidation;
using odataapimodels.Domain.ApiModels;

namespace odataapimodels.Domain.Validation;

public class ArtistValidator : AbstractValidator<ArtistApiModel>
{
    public ArtistValidator()
    {
        RuleFor(a => a.Name).NotNull();
        RuleFor(a => a.Name).MaximumLength(120);
    }
}