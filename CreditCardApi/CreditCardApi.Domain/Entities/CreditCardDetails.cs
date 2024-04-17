
namespace CreditCardApi.Domain.Entities;

public class CreditCardDetails: Entity<CreditCardDetailsID>
{
    public required CreditCardID CreditCarID { get; set; }
    public required CreditCardType CreditCardType { get; set; }
    public required double balance { get; set; }
    public required double Interest { get; set; }
    public required double Currentbalance { get; set; }
    public required double CurrentInterest { get; set; }
    public virtual CreditCard CreditCard { get; set; }
}
