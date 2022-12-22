using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YaraTechAssessment.Models;

namespace YaraTechAssessment.Controllers
{
    public class TeacherController : Controller
    {
        private readonly DataContext _context;
        public TeacherController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Teachers.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            Teacher teacher = new Teacher();
            return View(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
