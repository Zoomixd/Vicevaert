using System.Net.Mime;
using System.Text;
using System.Text.Json;
using Vicevært.Contract;
using Vicevært.Contract.Dtos;

namespace Vicevært.Web.Infrastructure
{
    public class BookingServiceProxy : IBookingService
    {
        private readonly HttpClient _client;

        public BookingServiceProxy(HttpClient client)
        {
            _client = client;
        }

        async Task IBookingService.CreateAsync(BookingDto bookingDto)
        {
            var bookingDtoJson = new StringContent(
                JsonSerializer.Serialize(bookingDto),
                Encoding.UTF8,
                MediaTypeNames.Application.Json);
            await _client.PostAsync("https://localhost:7008/api/Booking", bookingDtoJson);
        }


    }
}
