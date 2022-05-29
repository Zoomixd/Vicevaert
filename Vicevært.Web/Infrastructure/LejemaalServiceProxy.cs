using Vicevært.Contract;
using Vicevært.Contract.Dtos;

namespace Vicevært.Web.Infrastructure
{
    public class LejemaalServiceProxy : ILejemaalService
    {
        private readonly HttpClient _client;


        public LejemaalServiceProxy(HttpClient client)
        {
            _client = client;
        }



        async Task<LejemaalDto?> ILejemaalService.GetAsync(int id)
        {
            return await _client.GetFromJsonAsync<LejemaalDto?>($"api/Lejemaal/{id}");
        }

        async Task<IEnumerable<LejemaalDto>> ILejemaalService.GetAsync()
        {
            return await _client.GetFromJsonAsync<IEnumerable<LejemaalDto>>($"https://localhost:7008/api/Lejemaal");
        }
    }
}
