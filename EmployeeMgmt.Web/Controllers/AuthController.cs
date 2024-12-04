using Microsoft.AspNetCore.Mvc;

namespace EmployeeMgmt.Web.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
