using System.ComponentModel.DataAnnotations;

namespace CreditCardApi.Application.Dtos.CreditCard;

public class CreateCreditCardDto
{
    public required long CreditCardNumber { get; set; }
    public required string ClientName { get; set; }
    public required int CVV { get; set; }
    public required DateTime CreatedDate { get; set; }
    public required DateTime ExpirationDate { get; set; }
    public required DateTime PaymentDate { get; set; }
    public required DateTime CutOffDate { get; set; }
    public required CreateCreditCardDetailsDto CreditCardDetails { get; set; }
}
