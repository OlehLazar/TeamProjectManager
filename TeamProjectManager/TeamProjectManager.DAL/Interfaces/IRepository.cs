namespace TeamProjectManager.DAL.Interfaces;

public interface IRepository<TEntity>
{
	Task<IEnumerable<TEntity>> GetAllAsync();

	Task<IEnumerable<TEntity>> GetAsync(int skip, int take);

	Task<TEntity> GetByIdAsync(int id);

	Task AddAsync(TEntity entity);

	Task UpdateAsync(TEntity entity);

	Task DeleteAsync(TEntity entity);

	Task DeleteByIdAsync(int id);
}
