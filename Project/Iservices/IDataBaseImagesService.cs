using Microsoft.AspNetCore.Http;

namespace Project.IServices
{
    public interface IDataBaseImagesService
    {
        byte[] GetByteArrayFromImage(IFormFile file);
    }
}
