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
    public class IndexModel : PageModel
    {
        private readonly StudyApplicationFinalie.Areas.Identity.Data.ApplicationDbContext _context;

        public IndexModel(StudyApplicationFinalie.Areas.Identity.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<EnterModules> EnterModules { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.EnterModules != null)
            {
                EnterModules = await _context.EnterModules.ToListAsync();
            }
        }
    }
}
