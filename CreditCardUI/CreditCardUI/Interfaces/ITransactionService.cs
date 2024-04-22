using CreditCardUI.Models;

namespace CreditCardUI.Interfaces
{
    public interface ITransactionService
    {
        Task Create(CreateTransactionDto createTransactionDto);
        Task<ReportResponse> TransactionsDetails(Guid CreditCardId, DateTime FromDate);
        Task<Stream> TransactionsPDF(Guid CreditCardId, DateTime FromDate);
    }
}
