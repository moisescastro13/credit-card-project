
using CreditCardApi.Domain.Entities;
using System.Data;

namespace CreditCardApi.Infrastructure.Interfaces.Repositories;
public interface ITransactionRepository : IRepository<CreditCardTransaction, CreditCardTransactionID>
{
    public Task Add(DataTable entity);
}
