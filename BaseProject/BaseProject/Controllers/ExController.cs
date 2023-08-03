using BaseProject.Data.Service;
using BaseProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.Controllers
{
    public class ExController : Controller
    {
        private readonly IExService _exService;
        public ExController(IExService exservice) 
        {
            _exService = exservice;
        }
        public IActionResult Index()
        {
            ExModel exModel = new ExModel()
            {
                Name = "Ex"
            };
            _exService.AddAsync(exModel); // 저장할 모델
            _exService.UpdateAsync(0, exModel); // Id와 수정할 모델
            _exService.DeleteAsync(0);  // 삭제할 모델
            _exService.GetAllAsync(); // 모든 모델
            var result = _exService.GetByIdAsync(1); // Id로 모델 검색
            
            return View();
        }
    }
}
