using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Vicevært.Web.Pages.Lejer
{
    public class IndexModel : PageModel
    {
        private readonly Vicevært.Infrastructure.Database.DatabaseContext _context;

        public IndexModel(Vicevært.Infrastructure.Database.DatabaseContext context)
        {
            _context = context;
        }

        public IList<Domain.Entities.Lejer> Lejer { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Lejer != null)
            {
                Lejer = await _context.Lejer.ToListAsync();
            }
        }
    }
}
