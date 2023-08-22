using BaseProject.Data.Service;
using BaseProject.Data;
using BaseProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using BaseProject.Data.Static;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using BaseProject.Data.Enums;

namespace BaseProject.Controllers
{
    //[Authorize(Roles = UserRoles.InventoryManager)]
    [Route("Inventory")]
    public class InventoryController : Controller
    {
        private readonly IInventoryService _service;
        private readonly UserManager<UserIdentity> _userManager;
        private readonly BaseDbContext _dbContext;
        private readonly IFileService _fileService;

        public InventoryController(
            IInventoryService service
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
        public async Task<IActionResult> CreateInventory()
        {

            // Product_Models 와 Product_Create_Models를 조인하여 상품등록 페이지에 전달
            var result = _dbContext.Product_Models
                .Join(_dbContext.product_Create_Models,p => p.Id, c => c.ProductId,(p, c) => 
                new Inventoy_Post_Info_Model(){
                    ProductId = p.Id,
                    Name = p.Name,
                    Count = c.Count,
                })
                .ToList();



            return View(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateInventory(Inventoy_Get_Info_Model model)
        {
            // 파일 저장
            for (int i = 0; i < model.ProductId.Length; i++)
            {
                if (model.Count[i] != 0)
                {
                    var product = await _dbContext
                        .Product_Models
                        .Where(p => p.Id == model.ProductId[i])
                        .Include(p => p.ProductUseMetrailModels)
                        .FirstAsync();
                    var createProduct = await _dbContext
                        .product_Create_Models
                        .Where(p => p.ProductId == model.ProductId[i])
                        .FirstAsync();
                    product.Quantity += model.Count[i];
                    createProduct.Count -= model.Count[i];
                    Inventory_Model inventory_model = new Inventory_Model()
                    {
                        ProductId = model.ProductId[i],
                        Count = model.Count[i],
                        CreateTime = model.CreateTime[i],
                    };
                    _dbContext.Inventory_Models.Add(inventory_model);
                    foreach (var item in product.ProductUseMetrailModels)
                    {
                        var metrail = await _dbContext.Material_Models
                            .Where(m => m.Id == item.MetrailId).FirstAsync();

                        // 재료가 부족할 경우 추후 개발
                        //if(metrail.Quantity <= item.Quantity * model.Quantity[i])
                        //{
                        //    ViewBag.Message = "재료가 부족합니다.";
                        //    return Redirect("/Order/detail?id=" + model.Id);

                        //}
                        metrail.Quantity -= item.Quantity * model.Count[i];
                    }
                }
            }            
            await _dbContext.SaveChangesAsync();
            return Redirect("/Inventory/Read");
        }
        #endregion

        #region 상품목록조회

        [HttpGet("read")]
        [AllowAnonymous]
        public async Task<IActionResult> ReadInventory()
        {
            //var result = await _dbContext.Inventory_Models
            //        .Include(p => p.Product)
            //        .ToListAsync();      
            ViewBag.ProductsName = await Filter();
            return View();
        }
        [HttpPost("read")]
        public async Task<IActionResult> ReadInventory(string name,string Value)
        {
            var result = new List<Inventory_Model>();
            if(name != "전체")
            {
                result = await _dbContext.Inventory_Models
                        .Include(p => p.Product)
                        .Where(p => p.Product.Name == name)
                        .OrderByDescending(p => p.Id)
                        .ToListAsync();
            }
            else if( name == "전체")
            {
                  result = await _dbContext.Inventory_Models
                        .Include(p => p.Product)
                        .OrderByDescending(p => p.Id)
                        .ToListAsync();
            }
            ViewBag.Name = name;
            ViewBag.ProductsName = await Filter();
            return View(result);
        }

        public async Task<List<SelectListItem>> Filter()
        {
            var result = await _dbContext.Product_Models.Select(p => new SelectListItem()
            {
                Value = p.Name,
                Text = p.Name
            })
                .ToListAsync();
            result.Add(new SelectListItem() { Value = "전체", Text = "전체" });
            return result;
        }
        #endregion

        #region 상품상세조회
        [HttpGet("detail")]
        public IActionResult DetailInventory(int id)
        {
            // 상품 상세 정보 조회
            var result = _dbContext.Inventory_Models
                .Include(p => p.Product)
                .Where(p => p.Id == id)
                .First();
            return View(result);
        }
        #endregion        

        #region 상품수정
        [HttpPost("update")]
        public async Task<IActionResult> UpdateInventory(Inventory_Model model, Inventory_Edit_Log_Model log, IFormFile file)
        {
            // 수정할 정보 불러오기
            var UpdateModel = await _dbContext.Inventory_Models
                .Where(i => i.Id == model.Id)
                .FirstAsync();

            UpdateModel.Count = model.Count;
            UpdateModel.CreateTime = model.CreateTime;

            // 수정 시간 저장
            log.InventoryId = UpdateModel.Id;
            log.EditTime = DateTime.Now;

            _dbContext.Inventory_Edit_Log_Model.Add(log);

            _dbContext.SaveChanges();
            return Redirect("/Inventory/Read");
        }
        #endregion
    }
}

