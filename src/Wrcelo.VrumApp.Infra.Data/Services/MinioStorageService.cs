using Minio;
using Minio.DataModel.Args;
using Wrcelo.VrumApp.Infra.Data.Configs;

public class MinioStorageService
{
    private readonly IMinioClient _minioClient;
    private readonly MinioConfiguration _config;

    public MinioStorageService(MinioConfiguration config)
    {
        _config = config;
        _minioClient = new MinioClient()
            .WithEndpoint(_config.HostName, 9000)
            .WithCredentials(_config.UserName, _config.Password)
            .Build();
    }

    public async Task<string> UploadBase64ImageAsync(string base64, string fileName)
    {
        var bytes = Convert.FromBase64String(base64);
        using var stream = new MemoryStream(bytes);

        bool found = await _minioClient.BucketExistsAsync(new BucketExistsArgs().WithBucket(_config.BucketName));
        if (!found)
            await _minioClient.MakeBucketAsync(new MakeBucketArgs().WithBucket(_config.BucketName));

        await _minioClient.PutObjectAsync(new PutObjectArgs()
            .WithBucket(_config.BucketName)
            .WithObject(fileName)
            .WithStreamData(stream)
            .WithObjectSize(stream.Length)
            .WithContentType("image/jpeg"));

        return $"{_config.BucketName}/{fileName}";
    }
}
