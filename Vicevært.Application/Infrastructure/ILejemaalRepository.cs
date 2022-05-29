using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vicevært.Application.Infrastructure
{
    public interface ILejemaalRepository
    {
        Task<Domain.Entities.Lejemaal> GetAsync(int id);
    }
}
