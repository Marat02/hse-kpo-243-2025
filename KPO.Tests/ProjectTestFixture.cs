namespace KPO.Tests;

/// <summary>
/// Фикстура для тестов класса Project. Создается одна на все тесты.
/// </summary>
public class ProjectTestFixture
{
    public string Name = "Test Project";
    public string Target = "Test Target";
    public Guid Id = Guid.NewGuid();
}