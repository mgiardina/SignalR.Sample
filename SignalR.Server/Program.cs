using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SignalRServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls("http://localhost:5000");
                    webBuilder.ConfigureServices(services =>
                    {
                        services.AddSignalR();
                    });
                    webBuilder.Configure(app =>
                    {
                        app.UseRouting();
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapHub<MyHub>("/myhub");
                            endpoints.MapGet("/", async context =>
                            {
                                await context.Response.WriteAsync("SignalR Server Corriendo");
                            });
                        });
                    });
                })
                .Build();

            host.Run();
        }
    }
}