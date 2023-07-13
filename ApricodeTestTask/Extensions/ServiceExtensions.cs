using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace ApiServer.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {
            });
        }
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        /*public static void ConfigureDBContext(this IServiceCollection services,IConfiguration config)
        {
            // получаем строку подключения из файла конфигурации
            var connection = config["DefaultConnection"];

            // добавляем контекст ApplicationContext в качестве сервиса в приложение
            services.AddDbContext<ApplicationContext>(o=>o.UseSqlServer(connection));
        }*/
    }
}
