using BaseProject.Data;
using BaseProject.Data.Service;
using BaseProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.Controllers
{
    [Route("ex")]
    public class ExController : Controller
    {
        //private readonly IExService _exService;
        private readonly BaseDbContext _dbContext;
        public ExController( BaseDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            //ExModel exModel = new ExModel()
            //{
            //    Name = "Ex"
            //};
            //_exService.AddAsync(exModel); // 저장할 모델
            ////_exService.UpdateAsync(0, exModel); // Id와 수정할 모델
            //_exService.DeleteAsync(0);  // 삭제할 모델
            //_exService.GetAllAsync(); // 모든 모델
            //var result = _exService.GetByIdAsync(1); // Id로 모델 검색
            
            return View();
        }
        [HttpGet("test")]
        public string TestFun(int id)
        {
            Console.WriteLine(id);
            var teststring = _dbContext.Product_Models.Find(id);
            string result = "";
            result += teststring.Name + "/";
            result += teststring.Price.ToString() + "/";


            return result;
        }
    }
}
