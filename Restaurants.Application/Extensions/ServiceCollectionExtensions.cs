using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurants;
using Restaurants.Domain.Repositories;
using FluentValidation; // Requires FluentValidation.DependencyInjectionExtensions NuGet package
using FluentValidation.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assemblyName = typeof(ServiceCollectionExtensions).Assembly;
            services.AddScoped<IRestaurantService, RestaurantService>();

            services.AddAutoMapper(assemblyName);
            services.AddValidatorsFromAssembly(assemblyName).AddFluentValidationAutoValidation();
        }
    }
}
