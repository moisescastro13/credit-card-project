using CreditCardApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CreditCardApi.Infrastructure.Persistence.Repositories;

public class CreditCardRepository : EntityFrameworkRepository<CreditCard, CreditCardID>
{
    public CreditCardRepository(DbContext context) : base(context)
    {
    }
}
