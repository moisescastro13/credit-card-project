
using CreditCardApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CreditCardApi.Infrastructure.Persistence.Repositories;

public class CreditCardDetailsRepository : EntityFrameworkRepository<CreditCardDetails, CreditCardDetailsID>
{
    public CreditCardDetailsRepository(DbContext context) : base(context)
    {
    }
}
