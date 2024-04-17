
using CreditCardApi.Domain.Entities;

namespace CreditCardApi.Application.Dtos.CreditCard;

public class CreateCreditCardDetailsDto
{
    public required string Concept { get; set; }
    public required TransactionType TransactionType { get; set; }
    public required DateTime TransactionDate { get; set; }
    public required double Amount { get; set; }
}
