using Microsoft.Extensions.Configuration;
using System.IO;

public static class Configuration
{
    private static IConfigurationRoot _configuration;

    static Configuration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // Đường dẫn đến thư mục chứa file appsettings.json
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true); // Đọc file appsettings.json

        _configuration = builder.Build(); // Xây dựng cấu hình
    }

    public static string GetEncryptionKey()
    {
        return _configuration["EncryptionKey"]; // Trả về giá trị của khóa mã hóa
    }
}
