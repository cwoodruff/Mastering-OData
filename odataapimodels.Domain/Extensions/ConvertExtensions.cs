using odataapimodels.Domain.Converters;

namespace odataapimodels.Domain.Extensions;

public static class ConvertExtensions
{
    public static IEnumerable<TTarget> ConvertAll<TTarget>(
        this IEnumerable<IConvertModel<TTarget>> values)
        => values.Select(value => value.Convert());
}