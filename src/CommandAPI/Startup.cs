using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;

namespace CommandAPI;

public class Startup
{
    public void ConfigureServices(IServiceCollection services){
        // Section 1: Add Code Below
        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env){
        if (env.IsDevelopment()){
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>{
            endpoints.MapControllers();
        });
    }
}
