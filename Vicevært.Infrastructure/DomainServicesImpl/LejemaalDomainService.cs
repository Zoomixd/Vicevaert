using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vicevært.Domain.DomainServices;
using Vicevært.Infrastructure.Database;

namespace Vicevært.Infrastructure.DomainServicesImpl
{
    public class LejemaalDomainService : ILejemaalDomainService
    {
        private readonly DatabaseContext _db;

        public LejemaalDomainService(DatabaseContext db)
        {
            _db = db;
        }
        IEnumerable<Domain.Entities.Lejemaal> ILejemaalDomainService.GetExistingLejemaal(Domain.Entities.Lejemaal lejemaal)
        {
            return _db.Lejemaal.Where(b => b.LejemålId!= lejemaal.LejemålId).ToList();
        }
    }
}

