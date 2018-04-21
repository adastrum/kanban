using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Kanban.Web.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseApplicationInsights()
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
    }
}
