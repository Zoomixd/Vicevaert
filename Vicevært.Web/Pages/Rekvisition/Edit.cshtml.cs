using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vicevært.Domain.Entities;
using Vicevært.Infrastructure.Database;

namespace Vicevært.Web.Pages.Rekvisition
{
    public class EditModel : PageModel
    {
        private readonly Vicevært.Infrastructure.Database.DatabaseContext _context;

        public EditModel(Vicevært.Infrastructure.Database.DatabaseContext context)
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

            var rekvisition =  await _context.Rekvisition.FirstOrDefaultAsync(m => m.RekvisitionId == id);
            if (rekvisition == null)
            {
                return NotFound();
            }
            Rekvisition = rekvisition;
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

            _context.Attach(Rekvisition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RekvisitionExists(Rekvisition.RekvisitionId))
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

        private bool RekvisitionExists(int id)
        {
          return (_context.Rekvisition?.Any(e => e.RekvisitionId == id)).GetValueOrDefault();
        }
    }
}
