using System.Linq.Expressions;
using System.Collections.Generic;
using RESTAPIProject.Models.Villa;
using RESTAPIProject.Repository.IRepository.IRepository

namespace RESTAPIProject.Repository.IRepository.IVillaRepository
{
    public interface IVillaRepository : IRepository<Villa>
    {
        Task<IEnumerable<Villa>> GetByNameAsync(string name);
        Task UpdateAsync(Villa entity);
    }
}