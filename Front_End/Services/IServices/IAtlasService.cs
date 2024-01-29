using Front_End.Models;

namespace Front_End.Services.IServices
{
    public interface IAtlasService
    {
        Task<ResponseDto?> GetPhotosAsync();
        Task<ResponseDto?> GetPhotoByIdAsync(int id);
        Task<ResponseDto?> GetPhotoByTitleAsync(string title);
        Task<ResponseDto?> PostPhotoAsync(AtlasPhoto photo);
        Task<ResponseDto?> PutPhotoAsync(AtlasPhoto photo);
        Task<ResponseDto?> DeletePhotoAsync(int id);
    }
}
