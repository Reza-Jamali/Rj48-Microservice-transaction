﻿

using CarTax.Car.Domain.Repository;
using Library_EF;
using Microsoft.Extensions.DependencyInjection;



namespace CarTax.Car.Application.Configurtion.Servises
{
    public static class CarApplicationServiseConfigure
    {
        public static IServiceCollection AreaApplicationServiceConfig(this IServiceCollection services)
        {

            services.AddScoped(c =>
               new CarApplicationService
               (

                   c.GetService<ICarRepository>(),
                   c.GetService<IUnitOfWork>())

               );

            return services;

        }
    }
}
