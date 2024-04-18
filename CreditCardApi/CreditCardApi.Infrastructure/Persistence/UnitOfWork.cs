using CreditCardApi.Domain.Entities;
using CreditCardApi.Infrastructure.Interfaces;
using CreditCardApi.Infrastructure.Interfaces.Repositories;
using CreditCardApi.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace CreditCardApi.Infrastructure.Persistence;

internal class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private IDbContextTransaction _objTran;

    private ICreditCardRepository _creditCardRepository;
    private IRepository<CreditCardDetails, CreditCardDetailsID> _creditCardDetailsRepository;
    private ITransactionRepository _transactionRepository;
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
       
    }
    public ICreditCardRepository CreditCardRepository
    {
        get
        {
            _creditCardRepository = _creditCardRepository is null ? new CreditCardRepository(_context) : _creditCardRepository;
            return _creditCardRepository;
        }
    }
    public IRepository<CreditCardDetails, CreditCardDetailsID> CreditCardDetailsRepository
    {
        get
        {
            _creditCardDetailsRepository = _creditCardDetailsRepository is null ? new CreditCardDetailsRepository(_context) : _creditCardDetailsRepository;
            return _creditCardDetailsRepository;
        }
    }
    public ITransactionRepository TransactionRepository
    {
        get
        {
            _transactionRepository = _transactionRepository is null ? new TransactionRepository(_context) : _transactionRepository;
            return _transactionRepository;
        }
    }
    public async Task CommitAsync() => await _objTran.CommitAsync();

    public void CreateTransaction()
    {
        _objTran = _context.Database.BeginTransaction();
    }
    public void Dispose() => _context.Dispose();
    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    public void Rollback() => _objTran.Rollback();
}
