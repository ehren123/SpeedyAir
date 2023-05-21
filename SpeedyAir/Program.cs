using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SpeedyAir.Repositories;

using var host = CreateHostBuilder(args).Build();

using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;

IHostBuilder CreateHostBuilder(string[] strings)
{
    return Host.CreateDefaultBuilder()
        .ConfigureServices((_, services) =>
        {
            services.AddSingleton<App>();
            services.AddTransient<OrderRepository>();
        });
}

services.GetRequiredService<App>().Run(args);
