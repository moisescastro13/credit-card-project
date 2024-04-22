using CreditCardApi.Domain.Entities;
using CreditCardApi.Infrastructure.Interfaces.Repositories;
using CreditCardApi.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;

namespace CreditCardApi.Infrastructure.Persistence.Repositories;

public class CreditCardRepository : EntityFrameworkRepository<CreditCard, CreditCardID>, ICreditCardRepository
{
    public CreditCardRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<CreditCard?> GetOneWithInformation(CreditCardID creditCardID)
    {
        CreditCard? creditCard = await (from c in _context.CreditCards.AsQueryable()
                                        where c.Id == creditCardID
                                        select new CreditCard
                                        {
                                            Id = creditCardID,
                                            PaymentDate = c.PaymentDate,
                                            CVV = c.CVV,
                                            CreditCardNumber = c.CreditCardNumber,
                                            ClientName = c.ClientName,
                                            ExpirationDate = c.ExpirationDate,
                                            CreatedDate = c.CreatedDate,
                                            CutOffDate = c.CutOffDate,
                                            CreditCardDetails = c.CreditCardDetails,
                                            CreditCardTransactions = c.CreditCardTransactions.OrderBy(x => x.TransactionDate).ToList(),
                                        }).AsNoTracking().AsSplitQuery().SingleOrDefaultAsync();

        return creditCard;
    }

    public async Task<CreditCard?> GetById(CreditCardID creditCardID)
    {
        CreditCard? creditCard = await (from c in _context.CreditCards.AsQueryable()
                                 where c.Id == creditCardID
                                 select new CreditCard{ 
                                     Id = creditCardID,
                                     PaymentDate = c.PaymentDate,
                                     CVV = c.CVV,
                                     CreditCardNumber = c.CreditCardNumber,
                                     ClientName = c.ClientName,
                                     ExpirationDate = c.ExpirationDate,
                                     CreatedDate = c.CreatedDate,
                                     CutOffDate = c.CutOffDate,
                                     CreditCardDetails = c.CreditCardDetails
                                 }).AsNoTracking().FirstOrDefaultAsync();

        return creditCard;
    }
}
