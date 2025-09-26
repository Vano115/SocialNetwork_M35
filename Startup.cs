using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using System;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Hosting;
using SocialNetwork_M35.Services;
using SocialNetwork_M35.Data;
using SocialNetwork_M35.Data.DbSettings;
using Microsoft.AspNetCore.Routing;
using AutoMapper;
using System.Text;
using Microsoft.AspNetCore.Identity;
using SocialNetwork_M35.Data.Entityes;
using SocialNetwork_M35.Controllers;

namespace SocialNetwork_M35
{
    public class Startup
    {
        /// <summary>
        /// Загрузка конфигурации из файла Json
        /// </summary>
        private IConfiguration Configuration
        { get; } = new ConfigurationBuilder()
            .AddJsonFile("appsettings.Development.json")
          .Build();

        /// <summary>
        /// Логгер, для AutoMappera нужен ILoggerFactory
        /// </summary>
        private ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        public Startup() { }

        public void ConfigureServices(IServiceCollection services)
        {
            loggerFactory.CreateLogger<Startup>();
            loggerFactory.CreateLogger<RegisterController>();

            string connection = Configuration.GetConnectionString("DefaultConnection");

            services
                .AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection), ServiceLifetime.Singleton)
                .AddIdentity<User, IdentityRole>(opts =>
            {
                opts.Password.RequiredLength = 5;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            })
                .AddEntityFrameworkStores<ApplicationContext>();

            // Нам не нужны представления, но в MVC бы здесь стояло AddControllersWithViews()
            services.AddControllersWithViews();

            // Swagger
            services.AddOpenApiDocument();

            //services.AddScoped<IDeviceRepository, DeviceRepository>();
            //services.AddScoped<IRoomRepository, RoomRepository>();

            // FluentValidation для ручной проверки
            //services.AddScoped<IValidator<AddDeviceRequest>, AddDeviceRequestValidator>();

            // FluentValidation для авто проверки На сайте документации не рекомнедовано использовать авто проверку
            //services.AddValidatorsFromAssemblyContaining<AddDeviceRequestValidator>();

            // Automapper

            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            }, loggerFactory);

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Add OpenAPI 3.0 document serving middleware
                // Available at: http://localhost:<port>/swagger/v1/swagger.json
                app.UseOpenApi();

                // Add web UIs to interact with the document
                // Available at: http://localhost:<port>/swagger
                app.UseSwaggerUi(); // UseSwaggerUI Protected by if (env.IsDevelopment())
            }


            // Маршрутизация
            app.UseRouting();

            // Использование статических файлов
            app.UseStaticFiles();

            // Использование аутентификации
            app.UseAuthentication();

            // Использование авторизации
            app.UseAuthorization();

            // Сопоставляем маршруты с контроллерами
            app.UseEndpoints(endpoints =>
            endpoints.MapControllers());

            /*
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });*/
        }
    }
}
