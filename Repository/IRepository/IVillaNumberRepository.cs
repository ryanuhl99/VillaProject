using System.Linq.Expressions;
using System.Collections.Generic;
using RESTAPIProject.Models.VillaNumber;
using RESTAPIProject.Repository.IRepository.IRepository;

namespace RESTAPIProject.Repository.IRepository.IVillaNumberRepository
{
    public interface IVillaNumberRepository : IRepository<VillaNumber>
    {
        Task<IEnumerate<VillaNumber>> GetByDetailsKeywordAsync(string details);
        Task UpdateAsync(VillaNumber entity);
    }
}