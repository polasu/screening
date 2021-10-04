using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trinityScreening.Models;

namespace trinityScreening.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly screeningDBContext _context;

        public RegistrationController(screeningDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TblUser uc)
        {            
            if (ModelState.IsValid)
            {
                if (_context.TblUsers.Where(u => u.UserName == uc.UserName).Any())
                {
                    ViewBag.message = "";
                    TempData["Message"] = "The username " + uc.UserName + " is already exist please choose another username";
                }                   
                else
                {
                    TempData["Message"] = "";
                    _context.Add(uc);
                    _context.SaveChanges();
                    ViewBag.message = "The user " + uc.UserName + " is saved successfully";                    
                }                
            }
            return View("Index");
        }

       
    }
}
