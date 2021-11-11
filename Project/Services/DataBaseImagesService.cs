using Microsoft.AspNetCore.Http;
using Project.IServices;
using System.IO;

namespace Project.Services
{
    public class DataBaseImagesService : IDataBaseImagesService
    {
        public byte[] GetByteArrayFromImage(IFormFile file)
        {
            byte[] bytesArray = null;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                bytesArray = ms.ToArray();
            }
            return bytesArray;
        }
    }
}
