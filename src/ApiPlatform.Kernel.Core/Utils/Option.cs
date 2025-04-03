namespace ApiPlatform.Kernel.Core.Utils;

public record Option<T>
{
    private readonly T? _value;

    public bool IsSome { get; }

    private Option(T value)
    {
        _value = value;
        IsSome = true;
    }

    private Option()
    {
        IsSome = false;
    }

    public static readonly Option<T> None = new Option<T>();

    public static Option<T> Some(T value) => new Option<T>(value);

    public TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none)
    {
        return IsSome && _value is not null
            ? some(_value)
            : none();
    }

    public static implicit operator T(Option<T> opt)
    {
        return opt.IsSome && opt._value is not null
            ? opt._value
            : throw new InvalidCastException("Option does not contain a value");
    }
}
