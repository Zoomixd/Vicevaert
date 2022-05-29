using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vicevært.Application.Infrastructure
{
    public interface IRekvisitionRepository
    {
        Task AddAsync(Domain.Entities.Rekvisition rekvisition);

        Task<Domain.Entities.Rekvisition> GetAsync(int id);
    }
}
