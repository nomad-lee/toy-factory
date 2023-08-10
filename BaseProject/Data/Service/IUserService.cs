using BaseProject.Data.Base;
using BaseProject.Models;

namespace BaseProject.Data.Service
{
    public interface IUserService 
    {
        Task<string> FileUpload(UserIdentity model, IFormFile file);
        Task<string> FileUpdate(UserIdentity model, IFormFile file);
    }


}
