using System.Net.Mime;
using System.Text;
using System.Text.Json;
using Vicevært.Contract;
using Vicevært.Contract.Dtos;

namespace Vicevært.Web.Infrastructure
{
    public class RekvisitionServiceProxy : IRekvisitionService
    {

        private readonly HttpClient _client;


        public RekvisitionServiceProxy(HttpClient client)
        {
            _client = client;
        }

        async Task IRekvisitionService.CreateAsync(RekvisitionDto rekvisitionDto)
        {
            var rekvisitionDtoJson = new StringContent(
                JsonSerializer.Serialize(rekvisitionDto),
                Encoding.UTF8,
                MediaTypeNames.Application.Json);
            await _client.PostAsync("https://localhost:7008/api/Rekvisition", rekvisitionDtoJson);
        }

        async Task<RekvisitionDto?> IRekvisitionService.GetAsync(int id)
        {
            return await _client.GetFromJsonAsync<RekvisitionDto?>($"api/Rekvisition/{id}");
        }

        async Task<IEnumerable<RekvisitionDto>> IRekvisitionService.GetAsync()
        {
            return await _client.GetFromJsonAsync<IEnumerable<RekvisitionDto>>($"https://localhost:7008/api/Rekvisition");
        }
    }
}
