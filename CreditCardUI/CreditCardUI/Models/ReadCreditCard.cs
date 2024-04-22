namespace CreditCardUI.Models;

public class ReadCreditCard
{
    public Guid Id { get; set; }
    public required long CreditCardNumber { get; set; }
    public required string ClientName { get; set; }
    public required DateTime ExpirationDate { get; set; }
}
