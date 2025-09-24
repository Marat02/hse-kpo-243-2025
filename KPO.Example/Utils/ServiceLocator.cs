namespace KPO.Example.Utils;

public static class ServiceLocator
{
    private static readonly Dictionary<Type, Func<object>> _instances = new();

    public static void Register<T>(Func<T> factory)
    {
        _instances[typeof(T)] = () => factory();
    }

    public static T Resolve<T>()
    {
        return (T) _instances[typeof(T)].Invoke();
    }
}