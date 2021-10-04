using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trinityScreening.Models;

namespace trinityScreening.Controllers
{
    public class UserLoginController : Controller
    {
        private readonly screeningDBContext _context;

        public UserLoginController(screeningDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginView uc)
        {
            if (_context.TblUsers.Where(u => u.UserName == uc.UserName && u.Password == uc.Password).Any())
            {
                var usr = _context.TblUsers.Where(u => u.UserName == uc.UserName && u.Password == uc.Password).FirstOrDefault();                
                TempData["UserId"] = usr.Id.ToString();
                TempData["Message"] = "";                
                return RedirectToAction("Index", "Home");               
            }
            else
            {
                TempData["Message"] = "User Login Failed!!";
            }
            return View("Index");            
        }

    }
}
