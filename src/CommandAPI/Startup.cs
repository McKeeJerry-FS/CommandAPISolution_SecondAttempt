using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using CommandAPI.Data.Interfaces;
using CommandAPI.Data;
using Npgsql;
using AutoMapper;

namespace CommandAPI;

public class Startup
{

    private readonly IConfiguration _config;
    public Startup(IConfiguration config){
        _config = config;
    }

    public void ConfigureServices(IServiceCollection services){
        var builder = new NpgsqlConnectionStringBuilder();
        builder.ConnectionString = _config.GetConnectionString("PostgreSqlConnection");
        builder.Username = _config["UserId"];
        builder.Password = _config["Password"];

        // Section 1: Add Code Below
        services.AddDbContext<CommandDbContext>(options => options.UseNpgsql(builder.ConnectionString));

        services.AddControllers();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        //services.AddScoped<ICommandAPIRepo, MockCommandAPIRepo>();
        services.AddScoped<ICommandAPIRepo, SqlCommandsAPIRepo>();
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
