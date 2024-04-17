using CreditCardApi.Domain.Entities;

namespace CreditCardApi.Infrastructure.Persistence.Repositories;

public class TransactionRepository : EntityFrameworkRepository<CreditCardTransaction, CreditCardTransactionID>
{
    public TransactionRepository(ApplicationDbContext context) : base(context)
    {
    }
}
