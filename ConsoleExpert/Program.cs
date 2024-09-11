
using Core.Interface;
using Core.Repository;
using DataAccess;
using DataAccess.Interface;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
 


var logger = LogManager.GetCurrentClassLogger();

try

{

    IConfiguration configuration = new ConfigurationBuilder()
       .SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
       .Build();

    var coonexion = configuration.GetConnectionString("DefaultConnection");

    var _host = Host.CreateDefaultBuilder(args).ConfigureServices(services =>
    {
        services.AddDbContext<ExportDBContext>(options =>
      options.UseSqlServer(coonexion));

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
       
        services.AddScoped<IStoreProcedureRepository, StoreProcedureRepository>();
        services.AddScoped<IService, Service>();

    }).ConfigureLogging((context, logging) =>
    {
        logging.ClearProviders();
        logging.AddNLog(configuration.GetSection("Nlog"));

    }).Build();




    var app = _host.Services.GetRequiredService<IService>();
    await app.Run();

}

catch (Exception ex)

{



    // NLog: catch any exception and log it.

    logger.Error(ex, "Stopped program because of exception");

}

finally

{

    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)

    LogManager.Shutdown();

}
