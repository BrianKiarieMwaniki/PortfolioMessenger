namespace PortfolioMessenger.Api.Cors;

public static class CorsExtensions
{
    private const string allowedOriginSetting = "AllowedOrigin";

    public static IServiceCollection AddSendEmailCors(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(corsBuilder => 
            {
                var allowedOrigin = configuration[allowedOriginSetting] ?? throw new InvalidOperationException("AllowedOrigin is not set");
                corsBuilder.WithOrigins(allowedOrigin)
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
        });

        return services;
    }
}
