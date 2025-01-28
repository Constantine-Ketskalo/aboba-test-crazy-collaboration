
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QueryableAPI.Filters;
using QueryableAPI.Middlewares;
using QueryableCore.RepositoriesInterfaces;
using QueryableCore.Services;
using QueryableCore.Services.Interfaces;
using QueryableDatabase.Mapping;
using QueryableDatabase.Migrations;
using QueryableDatabase.Repositories;
using Shared.ConfigModels;

namespace QueryableAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<MsSqlContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(builder.Configuration.GetConnectionString("MsSqlContext"));
            });

            #region Dependency Injection
            builder.Services.AddTransient<IBuildingsRepository, BuildingsRepository>();
            builder.Services.AddTransient<IBuildingsService, BuildingsService>();

            var config = new MapperConfiguration(c => {
                c.AddProfile<QueryableDatabaseMapperProfile>();
            });
            config.AssertConfigurationIsValid();
            builder.Services.AddSingleton<IMapper>(s => config.CreateMapper());

            var identitySettingsSection = builder.Configuration.GetSection("AppIdentitySettings");
            builder.Services.Configure<AppIdentitySettings>(identitySettingsSection);
            #endregion

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add(new CrazyFilter());
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            var app = builder.Build();

            #region Middlewares
            app.UseMiddleware<LoggingMiddleware>();
            #endregion

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
