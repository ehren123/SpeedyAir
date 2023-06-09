﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SpeedyAir;
using SpeedyAir.Repositories;
using SpeedyAir.Services;

using var host = CreateHostBuilder(args).Build();

using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;

IHostBuilder CreateHostBuilder(string[] strings)
{
    return Host.CreateDefaultBuilder()
        .ConfigureServices(s =>
        {
            s.AddSingleton<App>();
            s.AddTransient<IFlightRepository, FlightRepository>();
            s.AddTransient<IOrderRepository, OrderRepository>();
            s.AddTransient<IShippingService, ShippingService>();
        });
}

return services.GetRequiredService<App>().Run(args);
