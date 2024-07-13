using System.Linq.Expressions;
using System.Collections.Generic;
using RESTAPIProject.Models.VillaNumber;
using RESTAPIProject.Repository.IRepository.IRepository;

namespace RESTAPIProject.Repository.IRepository.IVillaNumberRepository
{
    public interface IVillaNumberRepository : IRepository<VillaNumber>
    {
        Task<IEnumerable<VillaNumber>> GetByDetailsKeywordAsync(string details);
        Task UpdateNumberAsync(VillaNumber entity);
    }
}