using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting; // Needed for IWebHostEnvironment
using Microsoft.Extensions.Hosting; // Needed for IHostEnvironment (if applicable)

namespace RealEstate.ApplicationLayer.Contracts
{
    public interface IImageStorageService
    {
        Task<string> SaveImageAsync(IFormFile file, int propertyId);
        Task DeleteImageAsync(string imageUrl);
    
    }

}
