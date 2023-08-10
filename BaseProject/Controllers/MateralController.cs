using BaseProject.Data.Service;
using BaseProject.Data;
using BaseProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BaseProject.Data.Enums;

namespace BaseProject.Controllers
{
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
                model.ImgUrl = await _fileService.FileCreat(model.Name, ImgFile, "Materal");
                model.Status = model.Status;
                model.CreateTime = DateTime.Now;
                await _service.AddAsync(model);

                await _dbContext.SaveChangesAsync();
                return Redirect("/");
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
            [HttpGet("update")]
            public IActionResult UpdateMateral(int id)
            {
                // 수정할 상품 정보 불러오기
                var result = _service.GetByIdAsync(id);
                return View(result.Result);
            }
            [HttpPost("update")]
            public async Task<IActionResult> UpdateMateral(Material_Model model, IFormFile file)
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
                // 기존에 있던 파일의 경로
                string path = @"wwwroot/" + UpdateModel.ImgUrl;
         
            if(file != null)
            {
                UpdateModel.ImgUrl = await _fileService.FileUpdate(UpdateModel.Name, file, "product");
            }

            // 수정 시간 저장
            Material_Edit_Log_Model log = new Material_Edit_Log_Model()
            {
                MaterialId = UpdateModel.Id,
                EditTime = DateTime.Now,
            };
            _dbContext.Material_Edit_Log_Models.Add(log);
            _dbContext.SaveChanges();
                return Redirect("/Materal/read");
            }
            #endregion

            #region 상품삭제
            // 상품 삭제
            [HttpGet("delete")]
            public async Task<IActionResult> DeleteMateral(int id)
            {
                // 삭제할 정보 가져오기
                var Model = _dbContext
                               .Material_Models
                               .Where(m => m.Id == id)
                               .FirstOrDefault();
            if (Model.Status == StatusCategory.Activation)
            {
                Model.Status = StatusCategory.Deactivation;
            }
            else if (Model.Status == StatusCategory.Deactivation)
            {
                Model.Status = StatusCategory.Activation;
            }

            await _service.UpdateAsync(id, Model);
                return Redirect("/Materal/read");
            }
            #endregion
        }
    }
