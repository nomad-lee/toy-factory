using BaseProject.Data.Service;
using BaseProject.Data;
using BaseProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using BaseProject.Data.Enums;
using BaseProject.Data.Static;

namespace BaseProject.Controllers
{
    //[Authorize(Roles = UserRoles.OrderManager)]

    [Route("Order")]
    public class OrderController : Controller
    {
        private readonly IOrderService _service;
        private readonly UserManager<UserIdentity> _userManager;
        private readonly BaseDbContext _dbContext;
        private readonly IFileService _fileService;

        public OrderController(
            IOrderService service
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
        public async Task<IActionResult> CreateOrder()
        {
            var result = await _dbContext
                .Product_Models
                .ToListAsync();
            return View(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder(Order_Model model)
        {
            model.Status = Order_StatusCategory.작업대기;
            await _service.AddAsync(model);

            for (int i = 0; i < model.ProductId.Length; i++)
            {
                
                Order_Product_Model order_Product_Model = new Order_Product_Model()
                {
                    OrderId = model.Id,
                    ProductId = model.ProductId[i],
                    Quantity = model.Quantity[i]
                };
                _dbContext.Order_Products.Add(order_Product_Model);
            }

            // 파일 업로드후 모델 저장

            await _dbContext.SaveChangesAsync();
            return Redirect("/order/read");
        }
        #endregion

        #region 주문목록조회
        [HttpGet("Read")]
        [AllowAnonymous]
        public async Task<IActionResult> ReadOrder()
        {
            var result = _dbContext.Order_Models
                .OrderByDescending(o => o.Id)
                .ToList();
            return View(result);

            // 전체 주문 목록 조회

        }

        [HttpPost("Read")]
        [AllowAnonymous]
        public async Task<IActionResult> ReadOrder(DateTime start, DateTime end)
        {
            // 수정할 상품 정보 불러오기
            var result = await _dbContext.Order_Models
                .Where(o => o.RegisterDate >= start && o.RegisterDate <= end)
                .ToListAsync();
            return View(result);
        }
        #endregion

        #region 상품수정
        //[HttpGet("update")]
        //public IActionResult UpdateOrder(int id)
        //{
        //    // 수정할 상품 정보 불러오기
        //    var result = _service.GetByIdAsync(id);
        //    return View(result.Result);
        //}
        [HttpPost("update")]
        public async Task<IActionResult> UpdateOrder(Order_Model model)
        {

            var UpdateModel = await _dbContext.Order_Models
                .Where(product => product.Id == model.Id)
                .Include(p => p.OrderProducts)
                .FirstAsync();

            UpdateModel.Customer = model.Customer;
            UpdateModel.Status = model.Status;
            UpdateModel.RegisterDate = model.RegisterDate;
            UpdateModel.Deadline = model.Deadline;
            UpdateModel.OrderProducts.Clear();

            if(model.Quantity != null)
            {
                for (int i = 0; i < model.ProductId.Length; i++)
                {
                    Order_Product_Model use_Metrail_Model = new Order_Product_Model()
                    {
                        OrderId = model.Id,
                        ProductId = model.ProductId[i],
                        Quantity = model.Quantity[i]
                    };
                    _dbContext.Order_Products.Add(use_Metrail_Model);
                }
            }
           
            if(model.Status == Order_StatusCategory.작업완료)
            {
                for (int i = 0; i < model.ProductId.Length; i++)
                {
                    var product = await _dbContext.Product_Models
                        .Where(p => p.Id == model.ProductId[i])
                        .Include(p => p.ProductUseMetrailModels).FirstAsync();
                    product.Quantity -= model.Quantity[i];
                    
                }                    
            }

            // 수정 시간 저장
            Order_Edit_Log_Model log = new Order_Edit_Log_Model()
            {
                OrderId = UpdateModel.Id,
                EditTime = DateTime.Today,
            };
            _dbContext.Order_Edit_Log_Models.Add(log);
            _dbContext.SaveChanges();
            return Redirect("/Order/read");
        }
        #endregion

        #region 상품상세보기
        [HttpGet("detail")]
        public async Task<IActionResult> DetailOrder(int id)
        {
            // 수정할 상품 정보 불러오기
            try
            {
                var result = await _dbContext.Order_Models
                            .Where(o => o.Id == id)


                            .Include(p => p.OrderProducts)
                            .ThenInclude(p => p.Product)
                            .FirstAsync();
                var result2 = await _dbContext.Order_Models
                .Where(o => o.Id == id)
                .Include(p => p.OrderProducts)
                .FirstAsync();

                return View(result2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Redirect("/Order/read");

        }
        #endregion

        #region 상품기간조회
        [HttpPost("period")]
        public async Task<List<Order_Model>> PeriodOrder(DateTime start, DateTime end)
        {
            // 수정할 상품 정보 불러오기
            var result = await _dbContext.Order_Models
                .Where(o => o.RegisterDate >= start && o.RegisterDate <= end)
                .ToListAsync();
            return result;
        }
        #endregion

        #region 상품삭제
        // 상품 삭제
        [HttpGet("delete")]
        public async Task<IActionResult> DeleteOrder(int id, Order_StatusCategory Status)
        {
            // 삭제할 정보 가져오기
            var Model = _dbContext
                           .Order_Models
                           .FirstOrDefault();
            Model.Status = Status;

            await _service.UpdateAsync(id, Model);
            return Redirect("/product/list");
        }
        #endregion
    }
}
