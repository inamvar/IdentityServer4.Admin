using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Skoruba.IdentityServer4.AspNetIdentity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .UseKestrel(c => c.AddServerHeader = false)
                   .UseUrls("http://0.0.0.0:5050")
                   .UseStartup<Startup>();
                   
             
    }
}
