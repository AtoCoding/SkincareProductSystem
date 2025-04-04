using Microsoft.Extensions.Configuration;

namespace DataAccessLayer
{
    public class RepositoryCommon
    {
        public static string? GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            return config["ConnectionStrings:DefaultConnection"];
        }
    }
}
