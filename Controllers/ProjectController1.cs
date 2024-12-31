using Assesmant.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;

namespace Assesmant.Controllers
{
    public class ProjectController1 : Controller
    {
        private readonly AppDbContext _db;
        public ProjectController1(AppDbContext db)
        {
            _db = db;
        }


        public async Task<IActionResult> AllProject()
        {
            var all = await _db.Projects.ToListAsync();
            return View(all);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Project p)
        {
            if(p != null)
            {
                await _db.Projects.AddAsync(p);
                await _db.SaveChangesAsync();
                return RedirectToAction("AllProject");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var del = await _db.Projects.FindAsync(id);
            if(del != null)
            {
                return View(del);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Project p)
        {
            var del = await _db.Projects.FirstOrDefaultAsync(x => x.Project_Id == p.Project_Id);
            if(del != null)
            {
                _db.Projects.Remove(del);
                await _db.SaveChangesAsync();
                return RedirectToAction("AllProject");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var edit = await _db.Projects.FindAsync(id);
            if(edit != null)
            {
                return View(edit);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Project p)
        {
            var edit = await _db.Projects.FirstOrDefaultAsync(x => x.Project_Id == p.Project_Id);
            if(edit != null)
            {
                edit.Name = p.Name;
                edit.Description = p.Description;
                edit.StartDate = p.StartDate;
                edit.EndDate = p.EndDate;
                _db.Projects.Update(edit);
                await _db.SaveChangesAsync();
                return RedirectToAction("AllProject");
            }
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var det = await _db.Projects.FirstOrDefaultAsync(x => x.Project_Id == id);
           
            if (det != null)
            {
                return View(det);
            }
            return NotFound();
        }

    }
}
