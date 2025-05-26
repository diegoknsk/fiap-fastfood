using FastFood.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) =>
    {
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    })
    .ConfigureServices((context, services) =>
    {
        var connectionString =
            Environment.GetEnvironmentVariable("DEFAULT_CONNECTION") ??
            context.Configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<FastFoodDbContext>(options =>
            options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 0))));

        //options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    })
    .Build();

using (var scope = host.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<FastFoodDbContext>();
    db.Database.Migrate();
}