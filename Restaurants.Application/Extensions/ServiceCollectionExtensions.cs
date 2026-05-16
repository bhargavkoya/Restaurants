using FluentValidation; // Requires FluentValidation.DependencyInjectionExtensions NuGet package
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Users;
using Restaurants.Domain.Repositories;
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
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assemblyName));
            services.AddAutoMapper(assemblyName);
            services.AddValidatorsFromAssembly(assemblyName).AddFluentValidationAutoValidation();

            services.AddScoped<IUserContext, UserContext>();

            services.AddHttpContextAccessor();
        }
    }
}
