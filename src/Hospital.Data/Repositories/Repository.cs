using Hospital.Business.Interfaces;
using Hospital.Business.Models;
using Hospital.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Data.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    protected readonly HospitalContext Db;
    protected readonly DbSet<TEntity> DbSet;
    
    protected Repository(HospitalContext db)
    {
        Db = db;
        DbSet = db.Set<TEntity>();
    }
    
    public virtual async Task<List<TEntity>> GetAll()
    {
        return await DbSet.ToListAsync();
    }
    
    public virtual async Task<TEntity> GetById(Guid id)
    {
        return await DbSet.FindAsync(id);
    }
    
    public virtual async Task Add(TEntity entity)
    {
        DbSet.Add(entity);
        await SaveChanges();
    }

    public virtual async Task Update(TEntity entity)
    {
        DbSet.Update(entity);
        await SaveChanges();
    }

    public virtual async Task Remove(Guid id)
    {
        var entityToRemove = await DbSet.FindAsync(id);
        DbSet.Remove(entityToRemove);
        await SaveChanges();
    }

    public async Task<int> SaveChanges()
    {
        return await Db.SaveChangesAsync();
    }
    
    public void Dispose()
    {
        Db?.Dispose();
    }
}