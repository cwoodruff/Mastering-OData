using FluentValidation;
using odataapimodels.Domain.ApiModels;

namespace odataapimodels.Domain.Validation;

public class PlaylistValidator : AbstractValidator<PlaylistApiModel>
{
    public PlaylistValidator()
    {
        RuleFor(p => p.Name).NotNull();
        RuleFor(p => p.Name).MaximumLength(120);
    }
}