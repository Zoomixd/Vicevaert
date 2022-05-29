using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vicevært.Application.Contract;
using Vicevært.Application.Contract.Dtos;
using Vicevært.Infrastructure.Database;

namespace Vicevært.Infrastructure.Queries
{
    public class LejemaalQuery : ILejemaalQuery
    {
        private readonly DatabaseContext _db;

        public LejemaalQuery(DatabaseContext db)
        {
            _db = db;
        }

        async Task<LejemaalQueryDto?> ILejemaalQuery.GetLejemaalAsync(int id)
        {
            var result = await _db.Lejemaal.FindAsync(id);
            if (result is null) return new LejemaalQueryDto();


            return new LejemaalQueryDto
            {
                LejemålId = result.LejemålId,
                StreetName = result.StreetName,
                BuildingNumber = result.BuildingNumber,
                SecondaryAddress = result.SecondaryAddress,
                Postcode = result.Postcode,
                City = result.City,
                State = result.State,
                CountryCode = result.CountryCode,
                IsBookable = result.IsBookable
    };
        }

        async Task<IEnumerable<LejemaalQueryDto>> ILejemaalQuery.GetLejemaalAsync()
        {
            var result = new List<LejemaalQueryDto>();
            var dbLejemaal = await _db.Lejemaal.ToListAsync();
            dbLejemaal.ForEach(a => result.Add(new LejemaalQueryDto
            {
                LejemålId = a.LejemålId,
                StreetName = a.StreetName,
                BuildingNumber = a.BuildingNumber,
                SecondaryAddress = a.SecondaryAddress,
                Postcode = a.Postcode,
                City = a.City,
                State = a.State,
                CountryCode = a.CountryCode,
                IsBookable = a.IsBookable
            }));
            return result;
        }

    }
}

