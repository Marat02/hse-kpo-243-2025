namespace KPO.Example.Utils;

/// <summary>
/// Сервис локатор, похож на DependencyContainer, но статический и вызывается внутри класса
/// </summary>
public static class ServiceLocator
{
    /// <summary>
    /// Словарь зависимостей. Ключ - тип, значение - функция, которая создает экземпляр
    /// </summary>
    private static readonly Dictionary<Type, Func<object>> _instances = new();

    /// <summary>
    /// Регистрация зависимости
    /// </summary>
    /// <param name="factory">Функция, которая возвращает указанный тип Т</param>
    /// <typeparam name="T">Тип, который мы хотим зарегистрировать</typeparam>
    public static void Register<T>(Func<T> factory)
    {
        _instances[typeof(T)] = () => factory();
    }

    /// <summary>
    /// Возвращает экземпляр указанного типа. Ищет в словаре зависимости по типу и вызывает функцию, которая создает экземпляр
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Resolve<T>()
    {
        return (T) _instances[typeof(T)].Invoke();
    }
}