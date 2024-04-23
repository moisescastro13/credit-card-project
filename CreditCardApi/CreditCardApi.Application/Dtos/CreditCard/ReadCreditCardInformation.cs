using CreditCardApi.Application.Dtos.Transaction;

namespace CreditCardApi.Application.Dtos.CreditCard;

public class ReadCreditCardInformation
{
    public Guid Id { get; set; }
    public required long CreditCardNumber { get; set; }
    public required string ClientName { get; set; }
    public required int CVV { get; set; }
    public required DateTime CreatedDate { get; set; }
    public required DateTime ExpirationDate { get; set; }
    public required DateTime PaymentDate { get; set; }
    public required DateTime CutOffDate { get; set; }
    public required ReadCreditCardDetails CreditCardDetails { get; set; }
    public IEnumerable<ReadTransaction> Transactions { get; set; }
}
