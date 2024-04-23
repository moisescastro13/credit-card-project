
using CreditCardApi.Domain.Entities;

namespace CreditCardApi.Infrastructure.Interfaces.Repositories;

public interface ICreditCardRepository : IRepository<CreditCard, CreditCardID>
{
    Task<CreditCard?> GetOneWithInformation( CreditCardID creditCardID);
    Task<CreditCard?> GetById(CreditCardID creditCardID);
}
