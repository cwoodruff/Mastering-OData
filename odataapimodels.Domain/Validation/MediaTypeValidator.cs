using FluentValidation;
using odataapimodels.Domain.ApiModels;

namespace odataapimodels.Domain.Validation;

public class MediaTypeValidator : AbstractValidator<MediaTypeApiModel>
{
    public MediaTypeValidator()
    {
        RuleFor(m => m.Name).NotNull();
        RuleFor(m => m.Name).MaximumLength(120);
    }
}