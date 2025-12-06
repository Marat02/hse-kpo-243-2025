using Amazon.S3;
using Amazon.S3.Model;
using KPO.Example.Application.Repositories;

namespace KPO.Example.Infrastructure.Repositories;

public class FileRepository : IFileRepository
{
    private readonly IAmazonS3 _s3Client;

    public FileRepository(IAmazonS3 s3Client)
    {
        _s3Client = s3Client;
    }

    public async Task SaveFile(string fileName, Stream stream, CancellationToken cancellation)
    {
        var id = Guid.NewGuid();
        var request = new PutObjectRequest
        {
            BucketName = "kpo-example-bucket",
            Key = $"{id}/{fileName}",
            InputStream = stream
        };
        await _s3Client.PutObjectAsync(request, cancellation);
    }
}