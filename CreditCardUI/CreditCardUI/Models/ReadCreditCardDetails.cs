namespace CreditCardUI.Models;

public class ReadCreditCardDetails
{
    public Guid Id { get; set; }
    public required CreditCardType CreditCardType { get; set; }
    public required double balance { get; set; }
    public required double Interest { get; set; }
    public double Currentbalance { get; set; }
    public double CurrentInterest { get; set; }
    public double CreditableInterest { get; set; }
    public double MinimumFeeToPay { get; set; }
}
