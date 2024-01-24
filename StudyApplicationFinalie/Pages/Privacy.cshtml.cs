using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudyApplicationFinalie.Models;

namespace StudyApplicationFinalie.Pages
{
    [Authorize]
    public class PrivacyModel : PageModel
    {

        private readonly StudyApplicationFinalie.Areas.Identity.Data.ApplicationDbContext _context;

        public PrivacyModel(StudyApplicationFinalie.Areas.Identity.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<EnterModules> EnterModules { get; set; } = default!;
        public IList<EnterModules> EnterModules1 { get; set; } = default!;


        private readonly ILogger<PrivacyModel> _logger;

        public async Task OnGetAsync()
        {
            if (_context.EnterModules != null)
            {
                EnterModules = await _context.EnterModules.ToListAsync();
            }
        }
    }
}