namespace ApiPlatform.Kernel.Core.Extensions;

public static class TypeExtensions
{
    public static bool IsImplementationOf<T>(this Type type)
    {
        return type.IsImplementationOf(typeof(T));
    }

    public static bool IsImplementationOf(this Type type, Type implementedType)
    {
        return implementedType.IsAssignableFrom(type) ||
            type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == implementedType);
    }
}
