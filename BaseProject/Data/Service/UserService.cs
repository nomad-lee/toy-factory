using BaseProject.Data.Base;
using BaseProject.Models;
using System.IO;

namespace BaseProject.Data.Service
{
    public class UserService 
    {
        //private readonly BaseDbContext _dbContext;
        //private readonly IFileService _fileService;
        //public UserService(IFileService fileService)
        //{
        //    _fileService = fileService;
        //}



        //private async Task<string> FileUpload(UserIdentity model, IFormFile file, string pathName)
        //{
        //    try
        //    {
        //        // 파일이 저장될 경로
        //        string path = "wwwroot/" + pathName + "/ " + model.Id;
        //        // DB에 저장되는 파일의 경로
        //        string url = "/" + pathName + "/" + model.Id + "/" + file.FileName;
        //        // 여러개의 파일일 경우 하나씩 저장
        //        if (file.Length > 0)
        //        {
        //            string fileName = Path.GetFileName(Convert.ToString(file.FileName));

        //            //파일 업로드
        //            await _fileService.FileUpload(path, fileName, file);
        //        }
        //        return url;
        //    }
        //    catch (Exception ex)
        //    {
        //        // 파일 업로드 실패 처리
        //        Console.WriteLine(ex.Message);
        //        return "Fail";
        //    }
        //}
        //private async Task<string> FileUpdate(UserIdentity model, IFormFile file, string pathName)
        //{
        //    string path = "wwwroot/user/" + model.Id;
        //    await _fileService.FileDelete(path);
        //    return await FileUpload(model, file, pathName);

        //}

        //Task<string> IUserService.FileUpload(UserIdentity model, IFormFile file)
        //{
        //    return FileUpload(model, file, Us);
        //}

        //Task<string> IUserService.FileUpdate(UserIdentity model, IFormFile file)
        //{
        //    return FileUpdate(model, file);
        //}
    }
}
