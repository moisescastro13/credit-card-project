
namespace CreditCardApi.Domain.Entities;

public class CreditCardTransaction: Entity<CreditCardTransactionID>
{
    public required CreditCardID CreditCardID { get; set; }
    public required string Concept { get; set; }
    public required TransactionType TransactionType{ get; set; }
    public required DateTime TransactionDate { get; set; }
    public required double Amount { get; set; }
    public required double OldBalance { get; set; }
    public required double NewBalance { get; set; }
    public virtual CreditCard CreditCard { get; set; }
}
