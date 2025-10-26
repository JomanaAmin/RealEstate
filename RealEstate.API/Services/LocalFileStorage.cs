using RealEstate.ApplicationLayer.Contracts;

namespace RealEstate.API.Services
{
    public class LocalFileStorage: IImageStorageService
    {
        private readonly string _webRootPath;
        public LocalFileStorage(IWebHostEnvironment hostingEnvironment)
        {
            // Inject and store the physical path here, in the API/Infrastructure project
            _webRootPath = hostingEnvironment.WebRootPath;
        }
        public async Task<string> SaveImageAsync(IFormFile file, int propertyId) // here what i do is create a unique file name. Then, I construct the file path where the image will be saved in the wwwroot/images directory. Using a FileStream, I copy the contents of the uploaded file to the specified path asynchronously. Finally, I return the relative URL of the saved image.
        {
            string fileName = $"{Guid.NewGuid()}_{file.FileName}_{propertyId}";
            string filePath = Path.Combine(_webRootPath, "images", fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return $"/images/{fileName}";
        }
        public async Task DeleteImageAsync(string imageUrl)
        {
            string filePath = Path.Combine(_webRootPath, imageUrl.TrimStart('/'));
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }
    }
}
