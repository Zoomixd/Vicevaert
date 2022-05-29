using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vicevært.Application.Contract.Dtos;
using Vicevært.Infrastructure.Database;

namespace Vicevært.Infrastructure.Queries
{
    public class RekvisitionQuery : IRekvisitionQuery
    {


    private readonly DatabaseContext _db;

    public RekvisitionQuery(DatabaseContext db)
    {
        _db = db;
    }

        async Task<RekvisitionQueryDto?> IRekvisitionQuery.GetRekvisitionAsync(int id)
        {
            var result = await _db.Rekvisition.FindAsync(id);
            if (result is null) return new RekvisitionQueryDto();

            return new RekvisitionQueryDto
            {
                RekvisitionId = result.RekvisitionId,
                RekvisitionType = result.RekvisitionType,
                Kommentar = result.Kommentar,
                LejerId = result.LejerId
            };
        }

        async Task<IEnumerable<RekvisitionQueryDto>> IRekvisitionQuery.GetRekvisitionAsync()
        { 
            var result = new List<RekvisitionQueryDto>();
            var dbRekvisition = await _db.Rekvisition.ToListAsync();
            dbRekvisition.ForEach(a => result.Add(new RekvisitionQueryDto
            {
                RekvisitionId = a.RekvisitionId,
                RekvisitionType = a.RekvisitionType,
                Kommentar = a.Kommentar,
                LejerId = a.LejerId
        }));
            return result;
        }

    }
}
