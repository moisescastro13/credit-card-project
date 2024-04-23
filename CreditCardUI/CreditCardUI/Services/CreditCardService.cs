using CreditCardUI.Http.Routes;
using CreditCardUI.Interfaces;
using CreditCardUI.Models;
using Newtonsoft.Json;

namespace CreditCardUI.Services
{
    public class CreditCardService : ICreditCardService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        public CreditCardService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("Api");
        }


        public async Task<IEnumerable<ReadCreditCard>> GetAll()
        {
            var response = await _httpClient.GetAsync(ApiRoutes.CreaditCard);

            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<ReadCreditCard>>(responseString)!;
        }

        public async Task<ReadCreditCardInformation> GetCreditCardInformation(Guid id)
        {
            var response = await _httpClient.GetAsync($"{ApiRoutes.CreaditCard}/{id}");

            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ReadCreditCardInformation>(responseString)!;
        }

        public async Task Create(CreateCreditCardDto createCreditCardDto)
        {
            await _httpClient.PostAsJsonAsync($"{ApiRoutes.CreaditCard}", createCreditCardDto)
               .ContinueWith(task => task.Result.EnsureSuccessStatusCode());
        }
    }
}
