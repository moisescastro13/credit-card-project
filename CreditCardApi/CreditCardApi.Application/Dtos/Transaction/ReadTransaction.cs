
using CreditCardApi.Domain.Entities;

namespace CreditCardApi.Application.Dtos.Transaction;

public class ReadTransaction
{
    public string Concept { get; set; }
    public TransactionType TransactionType { get; set; }
    public DateTime TransactionDate { get; set; }
    public double Amount { get; set; }
    public double OldBalance { get; set; }
    public double NewBalance { get; set; }
}
