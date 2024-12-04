using Microsoft.AspNetCore.Mvc;
using EmployeeMgmt.Application.Interfaces;
using EmployeeMgmt.Application.DTOs;

namespace EmployeeMgmt.Web.Controllers
{
    public class AccountController : Controller
    {

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginDto model)
        {

            if (model.Username != "basheer" || model.Password != "12345")
            {
               
                ModelState.AddModelError("", "Invalid credentials. Please try again.");
            }
            if (ModelState.IsValid)
            {
                
                return RedirectToAction("Index", "Employee");
            }

            return View(model); 
        }
    }
}
