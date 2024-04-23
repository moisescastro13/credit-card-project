using CreditCardUI.Http.Routes;
using CreditCardUI.Interfaces;
using CreditCardUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CreditCardUI.Services;

public class TransactionService : ITransactionService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HttpClient _httpClientApi;
    private readonly HttpClient _httpClientService;
    public TransactionService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _httpClientApi = _httpClientFactory.CreateClient("Api");
        _httpClientService = _httpClientFactory.CreateClient("Reports");
    }


    public async Task Create(CreateTransactionDto createTransactionDto)
    {
        await _httpClientApi.PostAsJsonAsync($"{ApiRoutes.CreateTransaction}", createTransactionDto)
            .ContinueWith(task => task.Result.EnsureSuccessStatusCode());
    }

    public async Task<ReportResponse> TransactionsDetails(Guid CreditCardId, DateTime FromDate)
    {
        var uriBuilder = new UriBuilder(_httpClientService.BaseAddress! + $"{ApiRoutes.Report}");
        uriBuilder.Query = $"{nameof(CreditCardId)}={CreditCardId}&{nameof(FromDate)}={FromDate.ToString("yyyy-MM-ddTHH:mm:ss")}";

        var httpResponse = await _httpClientService.GetAsync(uriBuilder.ToString());

       
        string responseBody = await httpResponse.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<ReportResponse>(responseBody)!;
    }
    public async Task<Stream> TransactionsPDF(Guid CreditCardId, DateTime FromDate)
    {
        var uriBuilder = new UriBuilder(_httpClientService.BaseAddress! + $"{ApiRoutes.ReportPDF}");
        uriBuilder.Query = $"{nameof(CreditCardId)}={CreditCardId}&{nameof(FromDate)}={FromDate.ToString("yyyy-MM-ddTHH:mm:ss")}";

        var httpResponse = await _httpClientService.GetAsync(uriBuilder.ToString());


        return await httpResponse.Content.ReadAsStreamAsync();
    }
}
