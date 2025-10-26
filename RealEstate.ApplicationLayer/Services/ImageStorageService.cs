using Microsoft.AspNetCore.Http;
using RealEstate.ApplicationLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting; // Needed for IWebHostEnvironment
using Microsoft.Extensions.Hosting; // Needed for IHostEnvironment (if applicable)
namespace RealEstate.ApplicationLayer.Services
{
    internal class ImageStorageService : IImageStorageService
    {
        public async Task<string> SaveImageAsync (IFormFile file, int propertyId) // here what i do is create a unique file name. Then, I construct the file path where the image will be saved in the wwwroot/images directory. Using a FileStream, I copy the contents of the uploaded file to the specified path asynchronously. Finally, I return the relative URL of the saved image.
        {
            string fileName= $"{Guid.NewGuid()}_{file.FileName}_{propertyId}";
            string filePath = Path.Combine("wwwroot","images",fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return $"/images/{fileName}";
        }
        public async Task DeleteImageAsync(string imageUrl)
        {
            string filePath = Path.Combine("wwwroot", imageUrl.TrimStart('/'));
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }
    }
}
