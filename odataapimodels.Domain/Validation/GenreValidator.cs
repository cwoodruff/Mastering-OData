using FluentValidation;
using odataapimodels.Domain.ApiModels;

namespace odataapimodels.Domain.Validation;

public class GenreValidator : AbstractValidator<GenreApiModel>
{
    public GenreValidator()
    {
        RuleFor(g => g.Name).NotNull();
        RuleFor(g => g.Name).MaximumLength(120);
    }
}