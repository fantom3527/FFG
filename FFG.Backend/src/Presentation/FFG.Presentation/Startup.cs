using FFG.Application.Abstractions;
using FFG.Application.Extensions;
using FFG.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using FFG.Infrastructure.DataAccess.Extensions;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace FFG.Presentation
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration) 
            => _configuration = configuration;
    
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FFGDbContext>(options =>
            {
                var provider = _configuration.GetValue("provider", Provider.Sqlite.Name);

                options.UseSnakeCaseNamingConvention();

                if (provider == Provider.Sqlite.Name)
                {
                    options.UseSqlite(
                        _configuration.GetConnectionString(Provider.Sqlite.Name)!,
                        x => x.MigrationsAssembly(Provider.Sqlite.Assembly)
                    );
                }
                if (provider == Provider.PostgreSql.Name)
                {
                    options.UseNpgsql(
                        _configuration.GetConnectionString(Provider.PostgreSql.Name)!,
                        x => x.MigrationsAssembly(Provider.PostgreSql.Assembly)
                    );
                }
            });

            services.AddApplication();
            services.AddInfrastructureDataAccess();
            services.AddControllers();


            services.AddSwaggerGen(config =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath);
            });

            // Для теста предоставим доступ для всех
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                config.RoutePrefix = string.Empty;
                config.SwaggerEndpoint("swagger/v1/swagger.json", "CodeValues API");
            });

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
