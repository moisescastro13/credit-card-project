
using CreditCardApi.Domain.Entities;

namespace CreditCardApi.Infrastructure.Interfaces.Repositories;

public interface ICreditCardDetailsRepository : IRepository<CreditCardDetails, CreditCardDetailsID>
{
    Task<CreditCardDetails?> GetByCreditCardId(CreditCardID creditCardDetailsID);
}
