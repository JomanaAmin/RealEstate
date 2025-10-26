
using Microsoft.EntityFrameworkCore.Metadata;
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
            builder.Services.AddSwaggerGen();

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
