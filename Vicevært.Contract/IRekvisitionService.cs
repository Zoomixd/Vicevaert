using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vicevært.Contract.Dtos;

namespace Vicevært.Contract
{
    public interface IRekvisitionService
    {
        Task CreateAsync(RekvisitionDto rekvisitionDto);
        Task<RekvisitionDto?> GetAsync(int id);
        Task<IEnumerable<RekvisitionDto>> GetAsync();
    }
}
