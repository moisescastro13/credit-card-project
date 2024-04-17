
namespace CreditCardApi.Domain.Entities;

public class CreditCardTransaction: Entity<CreditCardTransactionID>
{
    public required CreditCardID CreditCarID { get; set; }
    public required string Concept { get; set; }
    public required TransactionType TransactionType{ get; set; }
    public required DateTime TransactionDate { get; set; }
    public required double Amount { get; set; }
}
