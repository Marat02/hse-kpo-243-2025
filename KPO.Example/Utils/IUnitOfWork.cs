using KPO.Example.Models.Projects;

namespace KPO.Example.Utils;

/// <summary>
/// Паттерн Unit-of-work. Нужен для консистеного сохраниения в хранилища. Сохранение происходить во время взова SaveChangesAsync
/// </summary>
public interface IUnitOfWork
{
    IProjectRepository ProjectRepository { get; }

    Task SaveChangesAsync(CancellationToken cancellation);
}