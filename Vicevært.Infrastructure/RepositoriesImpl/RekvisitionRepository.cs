using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vicevært.Application.Infrastructure;
using Vicevært.Domain.Entities;
using Vicevært.Infrastructure.Database;

namespace Vicevært.Infrastructure.RepositoriesImpl
{
    public class RekvisitionRepository : IRekvisitionRepository
    {

        private readonly DatabaseContext _db;

        public RekvisitionRepository(DatabaseContext db)
        {
            _db = db;
        }

        async Task<Domain.Entities.Rekvisition> IRekvisitionRepository.GetAsync(int id)
        {
            return await _db.Rekvisition.AsNoTracking().FirstOrDefaultAsync(a => a.RekvisitionId == id) ?? throw new Exception("Rekvisition not found");
        }

        async Task IRekvisitionRepository.AddAsync(Domain.Entities.Rekvisition rekvisition)
        {
            _db.Rekvisition.Add(rekvisition);
            await _db.SaveChangesAsync();
        }
    }
}
