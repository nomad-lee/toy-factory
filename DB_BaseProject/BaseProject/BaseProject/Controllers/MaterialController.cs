using BaseProject.Data;
using BaseProject.Data.Static;
using BaseProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseProject.Controllers
{
    [Route("material")]
    public class MaterialController : Controller
    {
        private readonly BaseDbContext _dbContext;

        public MaterialController(BaseDbContext baseDbContext)
        {
            _dbContext = baseDbContext;
        }


        [HttpGet("create")]
        public IActionResult CreateMaterial()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult CreateMaterial(MaterialModel model)
        {
            var result = _dbContext.Add(model);

            _dbContext.SaveChanges();

            return Redirect("/material/create");
        }

        [HttpGet("read")]
        public IActionResult ReadMaterial()
        {
            var result = _dbContext.MaterialModels;                

            return View(result);
        }

        [HttpGet("update")]
        public IActionResult UpdateMaterial()
        {
            var result = _dbContext.MaterialModels;

            return View(result);
        }

        [HttpPost("update")]
        public IActionResult UpdateMaterial(MaterialModel model)
        {
            var result = _dbContext.Add(model);

            _dbContext.SaveChanges();

            return Redirect("/material/update");
        }

        [HttpPost("delete")]
        public IActionResult DeleteMaterial(MaterialModel model)
        {
            var result = _dbContext.Add(model);

            _dbContext.SaveChanges();

            return Redirect("/material/delete");
        }

    }
}
