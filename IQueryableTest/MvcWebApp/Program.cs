using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QueryableCore.RepositoriesInterfaces;
using QueryableCore.Services.Interfaces;
using QueryableCore.Services;
using QueryableDatabase.Migrations;
using QueryableDatabase.Repositories;
using QueryableDatabase.Mapping;
using MvcWebApp.Mapping;

namespace MvcWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<MsSqlContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(builder.Configuration.GetConnectionString("MsSqlContext"));
            });

            #region Dependency Injection
            builder.Services.AddTransient<IBuildingsRepository, BuildingsRepository>();
            builder.Services.AddTransient<IBuildingsService, BuildingsService>();

            var config = new MapperConfiguration(mapConfig => {
                mapConfig.AddProfile<QueryableDatabaseMapperProfile>();
                mapConfig.AddProfile<MvcMapperProfile>();
            });
            config.AssertConfigurationIsValid();
            builder.Services.AddSingleton<IMapper>(s => config.CreateMapper());
            #endregion

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Buildings}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
