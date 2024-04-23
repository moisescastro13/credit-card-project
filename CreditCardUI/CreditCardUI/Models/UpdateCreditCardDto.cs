
namespace CreditCardUI.Models;

public class UpdateCreditCardDto
{
    public UpdateCreditCardDto()
    {
    }

    public UpdateCreditCardDto(Guid creditCardId, double? balance, double? interest, double? minimumFeePercent)
    {
        CreditCardId = creditCardId;
        this.balance = balance;
        Interest = interest;
        MinimumFeePercent = minimumFeePercent;
    }

    public Guid CreditCardId { get; set; }
    public double? balance { get; set; }
    public double? Interest { get; set; }
    public double? MinimumFeePercent { get; set; }


}

