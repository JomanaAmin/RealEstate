using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.ApplicationLayer.Contracts;
using RealEstate.ApplicationLayer.Services;


namespace RealEstate.ApplicationLayer
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection service) 
        {
            service.AddScoped<IPropertyService,PropertyService>();
            service.AddScoped<ICategoryService, CategoryService>();
            service.AddScoped<IPropertyTypeService, PropertyTypeService>();
            return service;
        }
    }
}
