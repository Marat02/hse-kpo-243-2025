namespace KPO.Example.Application.Repositories;

public interface IFileRepository
{
    Task<Stream> Get(string fileName, CancellationToken cancellationToken);

    Task Save(string fileName, Stream stream, CancellationToken cancellationToken);
}