namespace KPO.Example.Application.Repositories;

public interface IFileRepository
{
    Task SaveFile(string fileName, Stream stream, CancellationToken cancellation);
}