
namespace CreditCardApi.Domain.Entities;

public class CreditCard: Entity<CreditCardID>
{
    private readonly HashSet<CreditCardTransaction> _creditCardTransactions = new();
    public required long CreditCardNumber { get; set; }
    public required string ClientName { get; set; }
    public required int CVV { get; set; }
    public required DateTime CreatedDate { get; set; }
    public required DateTime ExpirationDate { get; set; }
    public required DateTime PaymentDate { get; set; }
    public required DateTime CutOffDate { get; set; }
    public required CreditCardDetails CreditCardDetails { get; set;}
    public IReadOnlyCollection<CreditCardTransaction> CreditCardTransactions => _creditCardTransactions;

    public CreditCard() 
    {
    }
}
