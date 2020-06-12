using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace PampaDevs.Shared.Jwt
{
    public static class SetupJwt
    {
        public static IServiceCollection AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration, string jwtSettingsKey = null)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            var settingsSection = configuration.GetSection(jwtSettingsKey ?? "JwtSettings");
            services.Configure<JwtSettings>(settingsSection);

            var settings = settingsSection.Get<JwtSettings>();
            var secretKey = Encoding.ASCII.GetBytes(settings.SecretKey);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = settings.Audience,
                    ValidIssuer = settings.Issuer
                };
            });

            return services;
        }
    }
}
