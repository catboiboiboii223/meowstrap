using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bloxstrap.Models.APIs
{
    public class IPInfoResponse
    {
        [JsonPropertyName("city")]
        public string City { get; set; } = null!;

        [JsonPropertyName("country")]
        public string Country { get; set; } = null!;

        [JsonPropertyName("region")]
        public string Region { get; set; } = null!;
    }

    public class IPInfoService
    {
        private static readonly HttpClient client = new HttpClient();

        // This method will make an HTTP GET request to the ipinfo.io API to get server IP info
        public async Task<IPInfoResponse?> GetServerIPInfoAsync()
        {
            try
            {
                // Replace "http://ipinfo.io/json" with your API URL or any other API that provides location info
                string url = "https://ipinfo.io/json";
                
                // Send the GET request and read the response as a string
                var response = await client.GetStringAsync(url);

                // Deserialize the JSON response into the IPInfoResponse object
                var ipInfo = JsonSerializer.Deserialize<IPInfoResponse>(response);

                return ipInfo;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
