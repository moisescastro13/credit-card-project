
using CreditCardApi.Domain.Entities;

namespace CreditCardApi.Infrastructure.Interfaces;

public interface IRepository<T, I> where I : BaseRecordID
{
    Task<T?> GetById(I id);
    Task<IEnumerable<T>> GetAll();
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}
