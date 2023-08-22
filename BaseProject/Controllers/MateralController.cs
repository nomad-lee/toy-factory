using BaseProject.Data.Service;
using BaseProject.Data;
using BaseProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BaseProject.Data.Enums;
using BaseProject.Data.Static;
using Microsoft.EntityFrameworkCore;

namespace BaseProject.Controllers
{
    //[Authorize(Roles = UserRoles.MateralManager)]
    [Route("materal")]
    public class MateralController : Controller
    {
        
            private readonly IMateralService _service;
            private readonly UserManager<UserIdentity> _userManager;
            private readonly BaseDbContext _dbContext;
            private readonly IFileService _fileService;

            public MateralController(
                IMateralService service
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
            public async Task<IActionResult> CreateMateral()
            {
                return View();
            }

            // 권한을 수준으로 실행 가능
            [HttpPost("create")]
            public async Task<IActionResult> CreateMateral(Material_Model model, IFormFile ImgFile)
            {
                // 파일 저장
                model.ImgUrl = await _fileService.FileCreat(Convert.ToString(model.Id), ImgFile, "Materal");
                model.Status = model.Status;
                model.CreateTime = DateTime.Now;
                await _service.AddAsync(model);

                await _dbContext.SaveChangesAsync();
                return Redirect("/Materal/read");
            }
        #endregion

        #region 자재추가
        [HttpGet("stored")]
        public async Task<IActionResult> StoredMateral()
        {
            var result = await _dbContext.Material_Models.ToListAsync();
            return View(result);
        }
        [HttpPost("stored")]
        public async Task<IActionResult> StoredMateral(Materal_Stored_Model model)
        {
            for (int i = 0; i < model.Quantity.Length; i++)
            {
                if (model.Quantity[i] == 0)
                {
                    continue;
                }
                var result = await _dbContext.Material_Models.Where(m => m.Id == model.MetrailId[i]).FirstAsync();
                result.Quantity += model.Quantity[i];
                Materal_Stored_Log_Model materal_Stored_Log_Model = new Materal_Stored_Log_Model()
                {
                    MetrailId = model.MetrailId[i],
                    Quantity = model.Quantity[i],
                    StoredTime = DateTime.Now
                };
                _dbContext.Materal_Stored_Log_Models.Add(materal_Stored_Log_Model);
            }
            _dbContext.SaveChanges();
            return Redirect("/Materal/read");
        }
        #endregion

        #region 상품목록조회
        [HttpGet("Read")]
            [AllowAnonymous]
            public async Task<IActionResult> ReadMateral()
            {
            // 전체 상품 목록 조회
            var result = _dbContext.Material_Models.ToList();
            return View(result);
            }
            #endregion

        #region 상품수정
            [HttpPost("update")]
            public async Task<IActionResult> UpdateMateral(Material_Model model, IFormFile ImgFile)
            {
                // 수정할 상품 정보 불러오기
                var UpdateModel = _dbContext
                                .Material_Models
                                .Where(m => m.Id == model.Id)
                                .FirstOrDefault();
                UpdateModel.Name = model.Name;
                UpdateModel.Quantity = model.Quantity;
                UpdateModel.Price = model.Price;
                UpdateModel.Status = model.Status;
         
            if(ImgFile != null)
            {
                UpdateModel.ImgUrl = await _fileService.FileUpdate(Convert.ToString(UpdateModel.Id), ImgFile, "Material");
            }

            // 수정 시간 저장
            Material_Edit_Log_Model log = new Material_Edit_Log_Model()
            {
                MetrailId = UpdateModel.Id,
                EditTime = DateTime.Today,
            };
            _dbContext.Material_Edit_Log_Models.Add(log);
            _dbContext.SaveChanges();
                return Redirect("/Materal/read");
            }
            #endregion
        }
    }
