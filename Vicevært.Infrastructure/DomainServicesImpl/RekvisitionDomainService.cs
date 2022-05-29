using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vicevært.Domain.DomainServices;
using Vicevært.Infrastructure.Database;

namespace Vicevært.Infrastructure.DomainServicesImpl
{
    public class RekvisitionDomainService : IRekvisitionDomainServices
    {

        private readonly DatabaseContext _db;

        public RekvisitionDomainService(DatabaseContext db)
        {
            _db = db;
        }
        IEnumerable<Domain.Entities.Rekvisition> IRekvisitionDomainServices.GetOtherRekvisitions(Domain.Entities.Rekvisition rekvisition)
        {
            return _db.Rekvisition.Where(b => b.RekvisitionId != rekvisition.RekvisitionId).ToList();
        }
    }
}

