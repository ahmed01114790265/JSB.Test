using JSB.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSB.Domain
{
   public static class DependencyInjection
    {
        public static IServiceCollection JSBDbContext(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<JSBDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("cs")));
            service.AddScoped<IBookRepository, BookRepository>();   
            service.AddScoped<ICategoryRepository, CategoryReposit>();

            return service;
        }

    }
}
