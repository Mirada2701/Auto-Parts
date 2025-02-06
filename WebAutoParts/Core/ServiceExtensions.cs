using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.MapperProfile;
using Core.Services;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public static class ServiceExtensions
    {
        public static void AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AppProfile));
        }
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPartsService,SparePartService>();
        }
        public static void AddFluentValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            // enable client-side validation
            services.AddFluentValidationClientsideAdapters();
            // Load an assembly reference rather than using a marker type.
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        }

    }
}
