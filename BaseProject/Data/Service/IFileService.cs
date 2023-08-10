using BaseProject.Data.Base;
using BaseProject.Models;

namespace BaseProject.Data.Service
{
    public interface IFileService
    {
        //Task FileUpload(string path, string fileName, IFormFile file);
        Task FileDelete(string path);

        Task<string> FileCreat(string model_id, IFormFile file, string pathName);
        Task<string> FileUpdate(string model_id, IFormFile file, string pathName);
    }
}
