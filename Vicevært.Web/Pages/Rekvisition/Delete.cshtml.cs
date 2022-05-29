using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vicevært.Domain.Entities;
using Vicevært.Infrastructure.Database;

namespace Vicevært.Web.Pages.Rekvisition
{
    public class DeleteModel : PageModel
    {
        private readonly Vicevært.Infrastructure.Database.DatabaseContext _context;

        public DeleteModel(Vicevært.Infrastructure.Database.DatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Domain.Entities.Rekvisition Rekvisition { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Rekvisition == null)
            {
                return NotFound();
            }

            var rekvisition = await _context.Rekvisition.FirstOrDefaultAsync(m => m.RekvisitionId == id);

            if (rekvisition == null)
            {
                return NotFound();
            }
            else 
            {
                Rekvisition = rekvisition;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Rekvisition == null)
            {
                return NotFound();
            }
            var rekvisition = await _context.Rekvisition.FindAsync(id);

            if (rekvisition != null)
            {
                Rekvisition = rekvisition;
                _context.Rekvisition.Remove(Rekvisition);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
