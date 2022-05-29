using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vicevært.Application.Contract.Dtos
{
    public interface IRekvisitionQuery
    {
        Task<RekvisitionQueryDto?> GetRekvisitionAsync(int id);
        Task<IEnumerable<RekvisitionQueryDto>> GetRekvisitionAsync();
    }
}
