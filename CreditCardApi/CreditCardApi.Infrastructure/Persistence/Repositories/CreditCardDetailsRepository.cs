
using CreditCardApi.Domain.Entities;
using CreditCardApi.Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CreditCardApi.Infrastructure.Persistence.Repositories;

public class CreditCardDetailsRepository : EntityFrameworkRepository<CreditCardDetails, CreditCardDetailsID> ,ICreditCardDetailsRepository
{
    public CreditCardDetailsRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<CreditCardDetails?> GetByCreditCardId(CreditCardID creditCardID)
    {
        CreditCardDetails? creditCard = await (from c in _context.CreditCardDetails.AsQueryable()
                                        where c.CreditCarID == creditCardID
                                        select c).AsNoTracking().FirstOrDefaultAsync();

        return creditCard;
    }
}
