using API.Data;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API;

public static class DependencyInjection
{
    public static IServiceCollection AddAPI(this IServiceCollection services, IConfiguration configuration)
    {
        // Local Configuration.
        // string? connectionString = configuration.GetConnectionString("DefaultConnection");
        //
        // services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

        // Docker Configuratio.
        string? connectionString = configuration.GetConnectionString("Postgres-Docker");

        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));


        services.AddScoped<IDbContext>(serviceProvider => serviceProvider.GetRequiredService<AppDbContext>());

        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<AppDbContext>());

        services.AddScoped<IAuthService, AuthService>();

        return services;
    }

    public static void ApplyMigration(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using AppDbContext dbContext =
            scope.ServiceProvider.GetRequiredService<AppDbContext>();

        dbContext.Database.Migrate();
    }
}
