using CreditCardApi.Domain.Entities;
using CreditCardApi.Infrastructure.Interfaces;
using CreditCardApi.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace CreditCardApi.Infrastructure.Persistence;

internal class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private IDbContextTransaction _objTran;

    private IRepository<CreditCard, CreditCardID> _creditCardRepository;
    private IRepository<CreditCardDetails, CreditCardDetailsID> _creditCardDetailsRepository;
    private IRepository<CreditCardTransaction, CreditCardTransactionID> _transactionRepository;
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
       
    }
    public IRepository<CreditCard, CreditCardID> CreditCardRepository
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
    public IRepository<CreditCardTransaction, CreditCardTransactionID> TransactionRepository
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
