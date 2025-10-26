using Microsoft.OpenApi.Models;
using RealEstate.API.CustomAttribute;
using RealEstate.API.Interfaces;
using RealEstate.API.Services;
using RealEstate.ApplicationLayer;
using RealEstate.ApplicationLayer.Contracts;
using RealEstate.DAL;
namespace RealEstate.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            // Inside RealEstate.API/Program.cs (or Startup.cs)

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RealEstate API", Version = "v1" });

                // 1. Define the Security Scheme
                c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
                {
                    Description = "API Key authorization header scheme. Enter your Admin Key in the format: Key",
                    Name = Constants.ApiKeyHeader, // e.g., "Admin-Token"
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "ApiKey"
                });

                // 2. Apply the Security Requirement Globally (or per method, if needed)
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                // Correctly reference the enum value from OpenApiReferenceType
                                Type = ReferenceType.SecurityScheme,
                                Id = "ApiKey"
                            },
                            Scheme = "oauth2",
                            Name = "ApiKey",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
                        });

            builder.Services.AddDataAccessLayer(builder.Configuration).AddApplicationLayer();
            builder.Services.AddScoped<IImageStorageService, LocalFileStorage>();
            builder.Services.AddTransient<IApiKeyAuthentication, ApiKeyAuthentication>();
            builder.Services.AddScoped<ApiKeyAuthorizationFilter>();
            builder.Services.AddHttpContextAccessor();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
