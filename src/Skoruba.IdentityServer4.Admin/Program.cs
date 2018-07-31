using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using Skoruba.IdentityServer4.Admin.Helpers;

namespace Skoruba.IdentityServer4.Admin
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
               .AddCommandLine(args)
               .Build();

            var host = BuildWebHost(args, configuration);

            //NOTE: Uncomment the line below to use seed data
            await DbMigrationHelpers.EnsureSeedData(host, false);

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args, IConfigurationRoot configuration ) =>
            WebHost.CreateDefaultBuilder(args)
                   .UseKestrel(c => c.AddServerHeader = false)
                   .UseUrls("http://0.0.0.0:9000")
                   .UseStartup<Startup>()
                   .UseSerilog()
                   .Build();        
    }
}