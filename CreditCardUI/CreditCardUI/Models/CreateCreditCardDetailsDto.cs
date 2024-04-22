namespace CreditCardUI.Models;

public class CreateCreditCardDetailsDto
{
    public required CreditCardType CreditCardType { get; set; }
    public required double balance { get; set; }
    public required double Interest { get; set; }
    public double MinimumFeePercent { get; set; }
}
