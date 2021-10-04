using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using trinityScreening.Models;

namespace trinityScreening.Controllers
{
    public class HomeController : Controller
    {
        private readonly screeningDBContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, screeningDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            UserQuestionAnswers uqa = new UserQuestionAnswers();
            uqa.QuestionsList = _context.TblQuestions.ToList();
            uqa.SelectedAnswer = false;
            return View(uqa);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] UserQuestionAnswers uc, IFormCollection frm)//(UserQuestionAnswers userQuestionAnswers, IFormCollection frm)
        {
            string res="";
            bool IsFailed = false;
            if (ModelState.IsValid)
            {
                TblUserQuestionAn tqa;
                TempData["Message"] = "";
                for (int i = 0; i< frm.Count()-1; i++) //; each (TblUserQuestionAn qc in uc)
                {
                    switch (i)
                    {
                        case 0:
                            res = frm["1"].ToString();
                            break;
                        case 1:
                            res = frm["2"].ToString();
                            break;
                        case 2:
                            res = frm["3"].ToString();
                            break;
                    }
                   if (res == "1")
                       IsFailed = true;
                    tqa = new TblUserQuestionAn();
                    tqa.UserId = (long.Parse(TempData["UserId"].ToString()));
                    tqa.QuestionId = i + 1;
                    tqa.UserQuestionAns = (res == "1" ? true : false);
                    _context.Add(tqa);
                    _context.SaveChanges();
                }

                if (IsFailed)
                    TempData["Message"] = "The user screen FAILED";
                else
                    ViewBag.message = "The user screen PASS";
            }
            return View("dataSample");
        }

    }
}
