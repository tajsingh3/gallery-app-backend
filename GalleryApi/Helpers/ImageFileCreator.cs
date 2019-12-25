using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace GalleryApi.Helpers
{
    public static class ImageFileCreator
    {
        public async static Task<string> CreateImageFile(IFormFile imageFile, string imagesFolderPath)
        {
            if (imageFile.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + "-" + imageFile.FileName;
                var filePath = Path.Combine(imagesFolderPath, fileName);

                using (var stream = System.IO.File.Create(filePath))
                {
                    await imageFile.CopyToAsync(stream);
                }

                var staticFilePath = Path.Combine("images", fileName);
                return staticFilePath;
            }

            return null;
        }
    }
}