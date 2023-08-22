using Microsoft.AspNetCore.Mvc;

namespace BaseProject.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return Redirect("/user/accessdenied");
        }
        #region 권한 없는 사용자가 접근했을 때 보내지는 페이지
        [HttpGet("accessdenied")]
        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }
        #endregion
    }
}
