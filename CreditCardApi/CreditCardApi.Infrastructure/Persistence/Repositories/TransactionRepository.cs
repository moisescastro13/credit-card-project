using CreditCardApi.Domain.Entities;
using CreditCardApi.Infrastructure.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CreditCardApi.Infrastructure.Persistence.Repositories;

public class TransactionRepository : EntityFrameworkRepository<CreditCardTransaction, CreditCardTransactionID>, ITransactionRepository
{
    public TransactionRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task Add(DataTable entity)
    {
        var parameter = new SqlParameter("@Transaction", SqlDbType.Structured)
        {
            TypeName = "dbo.TransactionTableType",
            Value = entity
        };
        await _context.Database.ExecuteSqlRawAsync($"EXEC InsertCreditCardTransaction @Transaction", parameters: new[] { parameter });
    }
}
