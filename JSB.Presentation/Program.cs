using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
 using JSB.Contracts;
using JSB.Application;

namespace JSB.Presentation;

public class program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddApplication(builder.Configuration);
        
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        var app = builder.Build();

      

        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors();
      
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Product}/{action=Index}"
               );
        });
        app.MapControllers();
        app.Run();

    }
}   