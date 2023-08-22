using BaseProject.Data;
using BaseProject.Data.Service;
using BaseProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace BaseProject.Controllers
{
    [Route("ex")]
    public class ExController : Controller
    {
        int index = 1;
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
        [HttpPost("modal")]
        public string Modal(string str)
        {
            return "Modal";
        }
        [HttpGet("createEx")]
        public async Task<string> CreateEx() 
        {
            //if (index % 2 == 0)
            //{
                
            //}
            //await _dbContext.IoT_Data_Models.Where(i => i.ProductId == 1).FirstAsync();
            //    (new IoT_Data_Model() 
            //{

            //    ProductId = 1,
            //    CreateTime = DateTime.Now

            //});
            //await _dbContext.SaveChangesAsync();

            return "success";
        }
        [HttpGet("test")]
        public string TestFun(string name)
        {
            // exmodel에 있는 name 의 데이터 10개만 가져온다
            var result = _dbContext.ExModels
                .Include(x => x.Product)
                .Where(x => x.Product.Name == name)
                .OrderByDescending(x => x.CreateTime)
                .Take(10)
                .ToList();

            

            JArray jArray = new JArray();
            foreach (var item in result)
            {
                JObject jObject = new JObject();
                jObject.Add("name", item.Product.Name);
                jObject.Add("CreateTime", item.CreateTime);
                jArray.Add(jObject);
            }

            return jArray.ToString();
        }

        [HttpGet("getid")]
        public string GetId(string id)
        {

            JObject jObject = new JObject();
            jObject.Add("id", id);
            return jObject.ToString();
        }
    }
}
