using Assesmant.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assesmant.Controllers
{
    public class TeamMembersController : Controller
    {
        private readonly AppDbContext _context;

        public TeamMembersController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var get = await _context.TeamMembers.Include(x => x.tasks).ToListAsync();

            return View(get);
        }


        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamMember = await _context.TeamMembers.FindAsync(id);
            if (teamMember == null)
            {
                return NotFound();
            }
            return View(teamMember);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TeamMember teamMember)
        {
            var edit = await _context.TeamMembers.FindAsync(id);
            if (edit != null)
            {
                edit.Name = teamMember.Name;
                edit.Email = teamMember.Email;
                edit.Role = teamMember.Role;
                _context.TeamMembers.Update(edit);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();



        }


        public async Task<IActionResult> Delete(int id)
        {


            var teamMember = await _context.TeamMembers
                .FirstOrDefaultAsync(m => m.Member_Id == id);
            if (teamMember == null)
            {
                return NotFound();
            }

            return View(teamMember);
        }


        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teamMember = await _context.TeamMembers.FindAsync(id);
            if (teamMember != null)
            {
                _context.TeamMembers.Remove(teamMember);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();

        }

        
    }
}
