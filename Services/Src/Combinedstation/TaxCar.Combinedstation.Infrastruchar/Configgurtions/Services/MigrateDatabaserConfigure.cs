﻿

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using TaxCar.Combinedstation.Infrastruchar;

namespace TaxCar.Combinedstation.Infrastruchar.Configurtions.Services
{
    public static class MigrateDatabaserConfigure
    {

        public static IServiceProvider MigrateDatabase(this IServiceProvider webApp)
        {
            using (var scope = webApp.CreateScope())
            {

                var appContext = scope.ServiceProvider.GetRequiredService<CombinedstationDBContext>();

                var retryPolicy = Policy
                    .Handle<Exception>()
                    .WaitAndRetry(new[]
                    {
                     TimeSpan.FromSeconds(5),
                     TimeSpan.FromSeconds(10),
                     TimeSpan.FromSeconds(15)
                    });

                retryPolicy.Execute(() =>
                {
                  
                    bool areMigrationsPending = appContext.AreMigrationsPending();
                    bool hasMigrationsApplied = appContext.HasMigrationsApplied();

                    if (!areMigrationsPending)
                    {
                        appContext.Database.Migrate();
                    }
                    else if (hasMigrationsApplied)
                    {
                        appContext.Database.EnsureCreated();
                       
                    }
                   

                });

            }

            return webApp;

        }

    }
}


