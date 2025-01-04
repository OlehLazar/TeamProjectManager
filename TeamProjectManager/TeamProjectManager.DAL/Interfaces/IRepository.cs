namespace TeamProjectManager.DAL.Interfaces;

public interface IRepository<TEntity>
{
	Task<IEnumerable<TEntity>> GetAllAsync();

	Task<IEnumerable<TEntity>> GetAsync(int skip, int take);

	Task<TEntity> GetByIdAsync(string id);

	Task<TEntity> AddAsync(TEntity entity);

	Task<TEntity> UpdateAsync(TEntity entity);

	Task<TEntity> DeleteAsync(TEntity entity);

	Task<TEntity> DeleteByIdAsync(string id);
}
