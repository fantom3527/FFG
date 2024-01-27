using FFG.Infrastructure.DataAccess;
using FFG.Presentation;

//TODO: Зарядить сюда логирование

var host = CreateHostBuilder(args).Build();

using (var scope = host.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<FFGDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception exception)
    {
        //Log.Fatal(exception, "An error occurred while app initialization");
    }
}

host.Run();

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });