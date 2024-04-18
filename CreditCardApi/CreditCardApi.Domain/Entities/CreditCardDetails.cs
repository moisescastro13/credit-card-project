
namespace CreditCardApi.Domain.Entities;

public class CreditCardDetails: Entity<CreditCardDetailsID>
{
    public CreditCardID CreditCarID { get; set; }
    public required CreditCardType CreditCardType { get; set; }
    public required double balance { get; set; }
    public required double Interest { get; set; }
    public double Currentbalance { get; set; }
    public double CurrentInterest { get; set; }
    public virtual CreditCard CreditCard { get; set; }
}
