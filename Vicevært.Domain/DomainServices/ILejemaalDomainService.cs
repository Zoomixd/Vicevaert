using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vicevært.Domain.DomainServices
{
    public interface ILejemaalDomainService
    {
        IEnumerable<Entities.Lejemaal> GetExistingLejemaal(Domain.Entities.Lejemaal lejemaal);
    }
}
