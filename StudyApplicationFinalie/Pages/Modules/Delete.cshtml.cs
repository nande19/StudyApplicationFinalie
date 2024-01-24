using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudyApplicationFinalie.Areas.Identity.Data;
using StudyApplicationFinalie.Models;

namespace StudyApplicationFinalie.Pages.Modules
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly StudyApplicationFinalie.Areas.Identity.Data.ApplicationDbContext _context;

        public DeleteModel(StudyApplicationFinalie.Areas.Identity.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public EnterModules EnterModules { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.EnterModules == null)
            {
                return NotFound();
            }

            var entermodules = await _context.EnterModules.FirstOrDefaultAsync(m => m.ModuleCode == id);

            if (entermodules == null)
            {
                return NotFound();
            }
            else 
            {
                EnterModules = entermodules;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.EnterModules == null)
            {
                return NotFound();
            }
            var entermodules = await _context.EnterModules.FindAsync(id);

            if (entermodules != null)
            {
                EnterModules = entermodules;
                _context.EnterModules.Remove(EnterModules);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
