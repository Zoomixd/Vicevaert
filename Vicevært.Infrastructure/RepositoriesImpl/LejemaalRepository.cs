using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vicevært.Application.Infrastructure;
using Vicevært.Infrastructure.Database;

namespace Vicevært.Infrastructure.RepositoriesImpl
{
    public class LejemaalRepository : ILejemaalRepository
    {
        private readonly DatabaseContext _db;

        public LejemaalRepository(DatabaseContext db)
        {
            _db = db;
        }

        async Task<Domain.Entities.Lejemaal> ILejemaalRepository.GetAsync(int id)
        {
            return await _db.Lejemaal.AsNoTracking().FirstOrDefaultAsync(a => a.LejemålId == id) ?? throw new Exception("Lejemål not found");
        }
    }
}
