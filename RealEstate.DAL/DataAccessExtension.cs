using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.DAL.DataContext;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RealEstate.DAL
{
    public static class DataAccessExtension
    {
        public static IServiceCollection AddDataAccessLayer(this IServiceCollection service, IConfigurationManager configurationManager) 
        {
            service.AddDbContext<RealEstateDataContext>(options => { options.UseSqlServer(configurationManager.GetConnectionString("RealEstateConnection")); });
            service.AddScoped<Contracts.IUnitOfWork, DataContext.UnitOfWork>();
            
            return service;
        }
    }
}
