using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trinityScreening.Models;

namespace trinityScreening.Controllers
{
    public class QAController : Controller
    {
        private readonly screeningDBContext _context;

        public QAController(screeningDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IEnumerable<TblQuestion>> getAllQuestions()
        {
            return await _context.TblQuestions.OrderBy(a => a.QuestionsOrder).ToListAsync();
        }
    }
}
