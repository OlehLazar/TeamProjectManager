namespace TeamProjectManager.DAL.Interfaces;

public interface IRepository<TEntity, TId>
{
	Task<IEnumerable<TEntity>> GetAllAsync();

	Task<IEnumerable<TEntity>> GetAsync(int skip, int take);

	Task<TEntity?> GetByIdAsync(TId id);

	Task AddAsync(TEntity entity);

	Task UpdateAsync(TEntity entity);

	Task DeleteAsync(TEntity entity);

	Task DeleteByIdAsync(TId id);
}
