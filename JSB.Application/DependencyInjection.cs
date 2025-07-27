using JSB.Application.Factory;
using JSB.Application.Service;
using JSB.Contracts.InterfaceFactory;
using JSB.Contracts.InterfaceService;
using JSB.Domain;
using JSB.Domain.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSB.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddJSBDbContext(configuration);
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBookFactory, BookFactory>();
            services.AddScoped<ICategoryFactory, CategoryFactory>();


            return services;
        }
    }
}
