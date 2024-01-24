using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudyApplicationFinalie.Areas.Identity.Data;
using StudyApplicationFinalie.Models;

namespace StudyApplicationFinalie.Pages.Modules
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly StudyApplicationFinalie.Areas.Identity.Data.ApplicationDbContext _context;

        public CreateModel(StudyApplicationFinalie.Areas.Identity.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {

                return Page();
        }

        [BindProperty]
        public EnterModules EnterModules { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            calculate();
            Remaining();
            _context.EnterModules.Add(EnterModules);
            //calculate();
            //Remaining();
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        public void calculate()
        {
            if (EnterModules.Weeks.Equals(0))
            {
                EnterModules.Selfhours = ((EnterModules.Credits * 10) / 1) - EnterModules.Classhours;
            }
            else
            {
                EnterModules.Selfhours = ((EnterModules.Credits * 10) / EnterModules.Weeks) - EnterModules.Classhours;
            }
        }
        public void Remaining()
        {
            EnterModules.HoursRemaining = EnterModules.Selfhours - 0;
        }
    }
}
