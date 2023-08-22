using BaseProject.Data;
using BaseProject.Data.Enums;
using BaseProject.Data.Service;
using BaseProject.Data.Static;
using BaseProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace BaseProject.Controllers
{
    //[Authorize(Roles = UserRoles.ProductManager)]

    [Route("Product")]
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        private readonly UserManager<UserIdentity> _userManager;
        private readonly BaseDbContext _dbContext;
        private readonly IFileService _fileService;
        static int i = 1;

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
            // 오늘의 생산량을 조회 해서 상산량을 적어준다
            // 값은 초음파로 측정한 값으로 적어준다

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
            model.CreateTime = DateTime.Today;
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
            Product_Create_Model product_Create_Model = new Product_Create_Model()
            {
                ProductId = model.Id,
                Count = 0,
                CreateTime = DateTime.Today
            };
            _dbContext.product_Create_Models.Add(product_Create_Model);
           
            // 파일 업로드후 모델 저장
            
            await _dbContext.SaveChangesAsync();
            return Redirect("/product/read");
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

        #region 상품입출고조회
        [HttpGet("storedList")]
        [AllowAnonymous]
        public async Task<IActionResult> StoredListProduct()
        {
            // 각 상품별 전체 출고량과 상품이름을 조회
            var result = await _dbContext.Order_Products
                 .Include(p => p.Product)
                 .Where(p => p.Order.Status == Order_StatusCategory.작업완료)
                 .GroupBy(p => p.ProductId)
                 .Select(p => new Product_Total_List_Model()
                 {
                     ProductName = p.Select(p => p.Product.Name).FirstOrDefault(),
                     StoredCount = p.Sum(p => p.Quantity),
                     StockedCount = 0
                 })
                 .ToListAsync();
            var Stockedresult = await _dbContext.Inventory_Models
                 .Include(p => p.Product)
                 .GroupBy(p => p.ProductId)
                 .Select(p => new Product_Total_List_Model()
                 {
                     StockedCount = p.Sum(p => p.Count)
                 })
                 .ToListAsync();
            for (int i = 0; i < result.Count; i++)
            {
                result[i].StockedCount = Stockedresult[i].StockedCount;
            }

            return View(result);
        }
        #endregion

        #region 테스트용 상품생산함수
        [HttpGet("createTest")]
        public async Task CreateProductTest()
        {
            int check = (i % 3) + 1;
            await Console.Out.WriteLineAsync("/////////////////////////////////////////////////////////////");
            await Console.Out.WriteLineAsync(Convert.ToString(check));
            i++;
            var product =  await _dbContext.product_Create_Models.Where(p => p.Id == check).FirstAsync();
            product.Count += 1;     
             IoT_Data_Model ioT_Data_Model =  new IoT_Data_Model()
            {
                ProductId = product.Id,
                CreateTime = DateTime.Now
            };
            var result1 =  await _dbContext.IoT_Data_Models.AddAsync(ioT_Data_Model);
            var result2 = await _dbContext.SaveChangesAsync();
        }
        #endregion

        #region 상품생산현황
        [HttpGet("productionList")]
        [AllowAnonymous]
        public async Task<IActionResult> ProductionList()
        {
            // 각 상품별 전체 출고량과 상품이름을 조회
            var result = await _dbContext.Product_Models.Select(p => new SelectListItem()
            {
                Value = p.Name,
                Text = p.Name
            })
            .ToListAsync();
            return View(result);
        }

        [HttpGet("filter")]
        [AllowAnonymous]
        public async Task<string> filter()
        {

            var result = _dbContext.IoT_Data_Models
                .Include(x => x.Product)
                .OrderByDescending(x => x.CreateTime)
                .Take(10)
                .ToList();
            JArray jArray = new JArray();
            foreach (var item in result)
            {
                JObject jObject = new JObject();
                jObject.Add("Name", item.Product.Name);
                jObject.Add("CreateTime", item.CreateTime);
                jArray.Add(jObject);
            }
            return jArray.ToString();
        }

        [HttpGet("ProductInfo")]
        public async Task<string> ProductInfo()
        {

            var result = await _dbContext.product_Create_Models
                .Include(x => x.Product)
                .ToListAsync();
            JArray jArray = new JArray();
            foreach (var item in result)
            {
                JObject jObject = new JObject();
                jObject.Add("Name", item.Product.Name);
                jObject.Add("Count", item.Count);
                jArray.Add(jObject);
            }
            return jArray.ToString();
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
        public async Task<IActionResult> UpdateProduct(Product_Model model, IFormFile ImgFile)
        {
            // 수정 할 모델 불러오기            
            var UpdateModel = await _dbContext.Product_Models
                .Where(product => product.Id == model.Id)
                .Include(p => p.ProductUseMetrailModels)
                .ThenInclude(p => p.Metrail)
                .FirstAsync();

            UpdateModel.Status = model.Status;

            // DB에 저장되어 있는 경로 수정
            if (ImgFile != null)
            {
                UpdateModel.ImgUrl = await _fileService.FileUpdate(Convert.ToString(UpdateModel.Id), ImgFile, "product");
            }
            // 수정 시간 저장
            Product_Edit_LogModel log = new Product_Edit_LogModel()
            {
                ProductId = UpdateModel.Id,
                EditTime = DateTime.Today,
            };
            _dbContext.Product_Edit_Log_Models.Add(log);
            _dbContext.SaveChanges();
            return Redirect("/product/read");
        }
        #endregion

        #region 상품상세보기
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
        #endregion


    }
}
