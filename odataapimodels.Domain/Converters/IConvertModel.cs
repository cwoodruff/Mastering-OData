namespace odataapimodels.Domain.Converters;

public interface IConvertModel<out TTarget>
{
    TTarget Convert();
}