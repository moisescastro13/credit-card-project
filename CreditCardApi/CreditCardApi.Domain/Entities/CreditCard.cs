
namespace CreditCardApi.Domain.Entities;

public class CreditCard: Entity<CreditCardID>
{
    public IEnumerable<CreditCardTransaction> CreditCardTransactions { get; set; }
    public required long CreditCardNumber { get; set; }
    public required string ClientName { get; set; }
    public required int CVV { get; set; }
    public required DateTime CreatedDate { get; set; }
    public required DateTime ExpirationDate { get; set; }
    public required DateTime PaymentDate { get; set; }
    public required DateTime CutOffDate { get; set; }
    public required CreditCardDetails CreditCardDetails { get; set;}

    public CreditCard() 
    {
    }

    public CreditCard(long creditCardNumber, string clientName, int cVV, DateTime createdDate, DateTime expirationDate, DateTime paymentDate, DateTime cutOffDate, CreditCardDetails creditCardDetails)
    {
        CreditCardNumber = creditCardNumber;
        ClientName = clientName;
        CVV = cVV;
        CreatedDate = createdDate;
        ExpirationDate = expirationDate;
        PaymentDate = paymentDate;
        CutOffDate = cutOffDate;
        CreditCardDetails = creditCardDetails;
    }
}
