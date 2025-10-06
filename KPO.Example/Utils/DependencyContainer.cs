namespace KPO.Example.Utils;

/// <summary>
/// Контейнер зависимостей
/// </summary>
public class DependencyContainer
{
    /// <summary>
    /// Словарь зависимостей. Ключ - тип, значение - функция, которая создает экземпляр
    /// </summary>
    private readonly Dictionary<Type, Func<DependencyContainer, object>> _instances = new();

    /// <summary>
    /// Регистрация зависимости
    /// </summary>
    /// <param name="factory">Функция, которая возвращает указанный тип Т</param>
    /// <typeparam name="T">Тип, который мы хотим зарегистрировать</typeparam>
    public void Register<T>(Func<DependencyContainer, T> factory)
    {
        _instances[typeof(T)] = (dependencyContainer) => factory(dependencyContainer);
    }

    /// <summary>
    /// Возвращает экземпляр указанного типа. Ищет в словаре зависимости по типу и вызывает функцию, которая создает экземпляр
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T Resolve<T>()
    {
        return (T) _instances[typeof(T)].Invoke(this);
    }
}