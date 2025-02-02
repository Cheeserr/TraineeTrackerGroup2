﻿namespace TraineeTracker.Service
{
    public interface IServiceLayer<T> where T : class
    {
        Task<T?> FindAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task RemoveAsync(T entity);
        Task Update(T entity);
        bool Exists(int id);
        Task SaveChangesAsync();
        Task AddAsync(T entity);
        bool IsNull();
    }
}
