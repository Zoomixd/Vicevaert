using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vicevært.Contract.Dtos;

namespace Vicevært.Contract
{
    public interface ILejemaalService
    {

        Task<LejemaalDto?> GetAsync(int id);
        Task<IEnumerable<LejemaalDto>> GetAsync();
    }
}
