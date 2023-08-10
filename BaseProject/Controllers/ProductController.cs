using BaseProject.Data;
using BaseProject.Data.Enums;
using BaseProject.Data.Service;
using BaseProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseProject.Controllers
{
    [Route("Product")]
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        private readonly UserManager<UserIdentity> _userManager;
        private readonly BaseDbContext _dbContext;
        private readonly IFileService _fileService;        

        public ProductController(
            IProductService service
            , UserManager<UserIdentity> userManager
            , BaseDbContext dbContext
            , IFileService fileService
            )
        {
            _service = service;
            _userManager = userManager;
            _dbContext = dbContext;
            _fileService = fileService;
        }

        #region 상품등록
        [HttpGet("create")]
        public async Task<IActionResult> CreateProduct()
        {
            var result = await _dbContext.Material_Models.ToListAsync();
            return View(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProduct(Product_Model model,  IFormFile ImgFile)
        {
            // 파일 저장
            if(ImgFile != null)
            {
                model.ImgUrl = await _fileService.FileCreat(model.Name, ImgFile, "product");
            }         
            model.CreateTime = DateTime.Now;
            await _service.AddAsync(model);

            for (int i = 0; i < model.MetrailId.Length; i++)
            {
                Product_Use_Metrail_Model use_Metrail_Model = new Product_Use_Metrail_Model()
                {
                    ProductId = model.Id,
                    MetrailId = model.MetrailId[i],
                    Quantity = model.count[i]
                };
                _dbContext.Product_Use_Metrail_Models.Add(use_Metrail_Model);
            }
           
            // 파일 업로드후 모델 저장
            
            await _dbContext.SaveChangesAsync();
            return Redirect("/");
        }
        #endregion

        #region 상품목록조회
        [HttpGet("Read")]
        [AllowAnonymous]
        public async Task<IActionResult> ReadProduct()
        {
            // 전체 상품 목록 조회
            var result = _dbContext.Product_Models
                .Include(p => p.ProductUseMetrailModels)
                .ThenInclude(p => p.Metrail)
                .ToList();
            return View(result);
        }
        #endregion

        #region 상품수정
        [HttpGet("update")]
        public IActionResult UpdateProduct(int id)
        {
            // 수정할 상품 정보 불러오기
            var result = _service.GetByIdAsync(id);
            return View(result.Result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> UpdateProduct(Product_Model model, IFormFile file)
        {
            // 수정 할 모델 불러오기            
            var UpdateModel = await _dbContext.Product_Models
                .Where(product => product.Id == model.Id)
                .Include(p => p.ProductUseMetrailModels)
                .ThenInclude(p => p.Metrail)
                .FirstAsync();

            UpdateModel.Name = model.Name;
            UpdateModel.Price = model.Price;
            UpdateModel.Status = model.Status;
            int index = 0;
            //UpdateModel.ProductUseMetrailModels.Clear();

            foreach (var metrail in UpdateModel.ProductUseMetrailModels)
            {
                if(metrail.Quantity == model.count[index])
                {
                    index++;
                    continue;
                    
                }
                else
                {
                    metrail.Quantity = model.count[index];
                    index++;
                }
                
            }
            // DB에 저장되어 있는 경로 수정
            if (file != null)
            {
                UpdateModel.ImgUrl = await _fileService.FileUpdate(UpdateModel.Name, file, "product");
            }
            // 수정 시간 저장
            Product_Edit_LogModel log = new Product_Edit_LogModel()
            {
                ProductId = UpdateModel.Id,
                EditTime = DateTime.Now,
            };
            _dbContext.Product_Edit_Log_Models.Add(log);
            _dbContext.SaveChanges();
            return Redirect("/product/read");
        }
        #endregion
        [HttpGet("detail")]
        public async Task<IActionResult> DetailProduct(int id)
        {
            // 상품 상세 정보 불러오기
            var result = await _dbContext.Product_Models
                .Where(product => product.Id == id)
                .Include(p => p.ProductUseMetrailModels)
                .ThenInclude(p => p.Metrail)
                .FirstAsync();
            return View(result);
        }
        #region 상품삭제
        // 상품 삭제
        [HttpGet("delete")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            // 삭제할 정보 가져오기
            var Model = _dbContext
                           .Product_Models
                           .Where(product => product.Id == id)
                           .FirstOrDefault();
            if(Model.Status == StatusCategory.Activation)
            {
                Model.Status = StatusCategory.Deactivation;
            }               
            else if(Model.Status == StatusCategory.Deactivation)
            {
                Model.Status = StatusCategory.Activation;
            }
            
            await _service.UpdateAsync(id, Model);
            return Redirect("/product/read");
        }
        #endregion
    }
}
