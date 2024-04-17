
using CreditCardApi.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace CreditCardApi.Infrastructure.Interfaces;

public interface IUnitOfWork: IDisposable
{
    IRepository<CreditCard, CreditCardID> CreditCardRepository { get; }
    IRepository<CreditCardDetails, CreditCardDetailsID> CreditCardDetailsRepository { get; }
    IRepository<CreditCardTransaction, CreditCardTransactionID> TransactionRepository { get; }

    Task<int> SaveChangesAsync();
    void CreateTransaction();
    Task CommitAsync();
    void Rollback();
}
