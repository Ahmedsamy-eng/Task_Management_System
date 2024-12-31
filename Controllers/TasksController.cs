using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assesmant.Models.Entities;
using Task = Assesmant.Models.Entities.Task;
using Assesmant.Models;

namespace Assesmant.Controllers
{
    public class TasksController : Controller
    {
        private readonly AppDbContext _context;

        public TasksController(AppDbContext context)
        {
            _context = context;
        }


        //public async Task<IActionResult> Index()
        //{
        //    var appDbContext = _context.Tasks.Include(t => t.project).Include(t => t.team_member);
        //    return View(await appDbContext.ToListAsync());
        //}


        //public async Task<IActionResult> Details(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var task = await _context.Tasks
        //        .Include(t => t.project)
        //        .Include(t => t.team_member)
        //        .FirstOrDefaultAsync(m => m.Task_Id == id);
        //    if (task == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(task);
        //}

        //[HttpGet]       
        //public IActionResult Create()
        //{
        //    return View();
        //}


        //[HttpPost]
        //public async Task<IActionResult> Create(Task task)
        //{
        //    var add = await _context.Tasks.Include(p => p.project)
        //         .FirstOrDefaultAsync(x => x.Task_Id == task.Task_Id);

        //    if(add != null)
        //    {
        //        await _context.Tasks.AddAsync(add);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var t = await _context.Tasks.FirstOrDefaultAsync(x => x.Task_Id == id);
            var p = await _context.Projects.ToListAsync();
            var a = await _context.TeamMembers.ToListAsync();

            ProjectViewModel model = new ProjectViewModel
            {
                ProjectList = p,
                TeamList = a,
                Status = t.Status,
                Description = t.Description,
                Priorty = t.Priorty,
                DeadLine = t.DeadLine,
                Pro_ID = t.Pro_Id,
                TeamMember_ID = t.Mem_ID,

            };
           return View(model);
                
        }

        
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProjectViewModel view)
        {
            var t = await _context.Tasks.FirstOrDefaultAsync(x => x.Task_Id == id);
            t.Task_Id = view.Task_Id;
            t.Status = view.Status;
            t.Description = view.Description;
            t.Priorty = view.Priorty;
            t.Title = view.Title;
            t.DeadLine = view.DeadLine;
            t.Pro_Id = view.Pro_ID;
            t.Mem_ID = view.TeamMember_ID;

            await _context.SaveChangesAsync();
            return RedirectToAction("AllProject", "ProjectController1");

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks
                .Include(t => t.project)
                .Include(t => t.team_member)
                .FirstOrDefaultAsync(m => m.Task_Id == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

      
        [HttpPost, ActionName("Delete")]
      
        public async Task<IActionResult> Delete(Task t)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Task_Id == t.Task_Id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
           
        }

        
    }
}
