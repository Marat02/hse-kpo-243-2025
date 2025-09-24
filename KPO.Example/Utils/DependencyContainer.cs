namespace KPO.Example.Utils;

public class DependencyContainer
{
    private readonly Dictionary<Type, Func<DependencyContainer, object>> _instances = new();

    public void Register<T>(Func<DependencyContainer, T> factory)
    {
        _instances[typeof(T)] = (dependencyContainer) => factory(dependencyContainer);
    }

    public T Resolve<T>()
    {
        return (T) _instances[typeof(T)].Invoke(this);
    }
}