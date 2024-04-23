
using CreditCardApi.Domain.Entities;
using CreditCardApi.Infrastructure.Interfaces.Repositories;
using Microsoft.Data.SqlClient;

namespace CreditCardApi.Infrastructure.Interfaces;

public interface IUnitOfWork: IDisposable
{
    ICreditCardRepository CreditCardRepository { get; }
    ICreditCardDetailsRepository CreditCardDetailsRepository { get; }
    ITransactionRepository TransactionRepository { get; }
    Task<int> SaveChangesAsync();
    void CreateTransaction();
    Task CommitAsync();
    void Rollback();
}
