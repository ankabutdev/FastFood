﻿using System.Threading.Tasks;

namespace FastFood.Interfaces;

public interface IRepository<TEntity, TViewModel>
{
    public Task<int> CreateAsync(TEntity entity);

    public Task<int> UpdateAsync(long id, TEntity entity);

    public Task<int> DeleteAsync(long id);

    public Task<TViewModel> GetProductByIdAsync(long id);

    public Task<long> CountAsync();
}
