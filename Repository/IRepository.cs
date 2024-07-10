using System.Linq.Expressions;
using System.Collections.Generic;
using RESTAPIProject.Models.Villa;

namespace RESTAPIProject.Repository.IRepository
{
    public interface IVillaRepository
    {
        Task<List<Villa>> GetAllAsync(Expression<Func<Villa, bool>> filter = null);
        Task<Villa> GetByIdAsync(int id);
        Task<IEnumerable<Villa>> GetByNameAsync(string name);
        Task CreateAsync(Villa entity);
        Task UpdateAsync(Villa entity);
        Task RemoveAsync(Villa entity);
        Task SaveAsync();
    }
}