using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vicevært.Domain.DomainServices
{
    public interface IRekvisitionDomainServices
    {
        IEnumerable<Entities.Rekvisition> GetOtherRekvisitions(Domain.Entities.Rekvisition rekvisition);
    }
}
