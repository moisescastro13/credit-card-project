
using CreditCardApi.Domain.Entities;
using CreditCardApi.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CreditCardApi.Infrastructure.Persistence.Repositories;

public abstract class EntityFrameworkRepository<T, I> : IRepository<T, I> where T : Entity<I> where I : BaseRecordID 
{
    protected readonly DbContext _context;
    protected readonly DbSet<T> _dbSet;

    public EntityFrameworkRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<T?> GetById(I id)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Id.value == id.value);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task Add(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
    }

    public async Task Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
}
