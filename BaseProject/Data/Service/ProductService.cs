using BaseProject.Data.Base;
using BaseProject.Models;
using System.IO;

namespace BaseProject.Data.Service
{
    public class ProductService : EntityBaseRepository<Product_Model>, IProductService
    {
        //private readonly IFileService _fileService;


        public ProductService(BaseDbContext context) : base(context)
        {

        }

        //private async Task<string> ImgUpload(Product_Model model, IFormFile file)
        //{
        //    try
        //    {	// 여러개의 파일일 경우 하나씩 저장
        //            // 저장될 경로
        //            string filePath = "/Product/";
        //            // 저장될 상품 이름
        //            var ProductName = model.Name;
        //            if (file.Length > 0)
        //            {
        //                // 파일이 저장될 경로
        //                string path = "wwwroot" + filePath + ProductName;
        //                // DB에 저장되는 파일의 경로
        //                model.ImgUrl = filePath + ProductName + "/" + file.FileName;
        //                string fileName = Path.GetFileName(Convert.ToString(file.FileName));

        //                //파일 업로드
        //                _fileService.FileUpload(path, fileName, file);
        //            }
        //            // 수정시 반환될 파일 경로
        //        return model.ImgUrl;
        //    }
        //    catch (Exception ex)
        //    {
        //        // 파일 업로드 실패 처리
        //        Console.WriteLine(ex.Message);
        //        return "False";
        //    }
        //}

        //Task<string> IProductService.ImgUpload(Product_Model model, IFormFile file)
        //{
        //    return ImgUpload(model, file);
        //}
    }
}
