
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TeamHeritageAPI.Banco;

public class DAL<T> : IRepository<T> where T : class
{
    private readonly TeamHeritageDbContext _context;
    private readonly DbSet<T> _dbSet;

    public DAL(TeamHeritageDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<T> BuscaPorAsync(Expression<Func<T, bool>> condicao)
    {
        return await _dbSet.FirstOrDefaultAsync(condicao);
    }
}
