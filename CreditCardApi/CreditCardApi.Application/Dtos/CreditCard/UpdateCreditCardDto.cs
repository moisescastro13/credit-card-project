
namespace CreditCardApi.Application.Dtos.CreditCard;

public class UpdateCreditCardDto
{
    public Guid CreditCardId { get; set; }
    public double? balance { get; set; }
    public double? Interest { get; set; }
    public double? MinimumFeePercent { get; set; }
}
