using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudyApplicationFinalie.Areas.Identity.Data;
using StudyApplicationFinalie.Models;

namespace StudyApplicationFinalie.Pages.Modules
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly StudyApplicationFinalie.Areas.Identity.Data.ApplicationDbContext _context;

        public EditModel(StudyApplicationFinalie.Areas.Identity.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EnterModules EnterModules { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.EnterModules == null)
            {
                return NotFound();
            }

            var entermodules =  await _context.EnterModules.FirstOrDefaultAsync(m => m.ModuleCode.Equals(id));
            if (entermodules == null)
            {
                return NotFound();
            }
            EnterModules = entermodules;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Remaining();
            _context.Attach(EnterModules).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnterModulesExists(EnterModules.ModuleCode))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        public void Remaining()
        {
            EnterModules.HoursRemaining = EnterModules.Selfhours - EnterModules.Enteredhours;
        }
        private bool EnterModulesExists(string id)
        {
          return _context.EnterModules.Any(e => e.ModuleCode == id);
        }
    }
}
