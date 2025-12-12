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

    public async Task<Stream> Get(string fileName, CancellationToken cancellationToken)
    {
        var request = new GetObjectRequest
        {
            BucketName = "kpo-example-bucket",
            Key = fileName
        };
        return (await _s3Client.GetObjectAsync(request, cancellationToken)).ResponseStream;
    }

    public async Task Save(string fileName, Stream stream, CancellationToken cancellationToken)
    {
        var request = new PutObjectRequest
        {
            BucketName = "kpo-example-bucket",
            Key = $"{fileName}",
            InputStream = stream
        };
        await _s3Client.PutObjectAsync(request, cancellationToken);
    }
}