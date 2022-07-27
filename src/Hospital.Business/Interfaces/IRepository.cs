using Hospital.Business.Models;

namespace Hospital.Business.Interfaces;

public interface IRepository<TEntity> : IDisposable where TEntity : Entity
{
    Task<List<TEntity>> GetAll();
    Task<TEntity> GetById(Guid id);
    Task Add(TEntity entity);
    Task Update(TEntity entity);
    Task Remove(Guid id);
    Task<int> SaveChanges();
}