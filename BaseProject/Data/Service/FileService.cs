using BaseProject.Data.Base;
using BaseProject.Models;
using System.IO;

namespace BaseProject.Data.Service
{
    public class FileService : IFileService
    {
        private async Task FileUpload(string path, string fileName, IFormFile file)
        {
            // 경로에 파일이 없으면 생성                        
            if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }

            // 파일 저장
            string filePath = Path.Combine(path, fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
        }

        private async Task FileDelete(string path)
        {
            if (System.IO.File.Exists(path))
            {
                try
                {
                    System.IO.File.Delete(path);
                }
                catch (System.IO.IOException e)
                {
                    await Console.Out.WriteLineAsync(e.Message);
                    // handle exception
                }
            }
        }

        private async Task<string> FileCreat(string model_id, IFormFile file, string pathName)
        {
            try
            {
                // 파일이 저장될 경로
                string path = "wwwroot/" + pathName + "/" + model_id;
                // DB에 저장되는 파일의 경로
                string url = "/" + pathName + "/" + model_id + "/" + file.FileName;
                // 여러개의 파일일 경우 하나씩 저장
                if (file.Length > 0)
                {
                    string fileName = Path.GetFileName(Convert.ToString(file.FileName));

                    //파일 업로드
                    await FileUpload(path, fileName, file);
                }
                return url;
            }
            catch (Exception ex)
            {
                // 파일 업로드 실패 처리
                Console.WriteLine(ex.Message);
                return "Fail";
            }
        }

        private async Task<string> FileUpdate(string model_id, IFormFile file, string pathName)
        {
            string path = "wwwroot/" + pathName + "/" + model_id;
            await FileDelete(path);
            return await FileCreat(model_id, file, pathName);

        }

        Task IFileService.FileDelete(string path)
        {
            return FileDelete(path);
        }

        Task<string> IFileService.FileCreat(string model_id, IFormFile file, string pathName)
        {
            return FileCreat(model_id, file, pathName);
        }

        Task<string> IFileService.FileUpdate(string model_id, IFormFile file, string pathName)
        {
            return FileUpdate(model_id, file, pathName);
        }

        //Task IFileService.FileUpload(string path, string fileName, IFormFile file)
        //{
        //    return FileUpload(path, fileName, file);
        //}


    }
}
