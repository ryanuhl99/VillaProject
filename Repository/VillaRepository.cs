using RESTAPIProject.Repository.IRepository;
using RESTAPIProject.Data.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Collections.Generic;
using RESTAPIProject.Models.VillaClass;
using RESTAPIProject.Repository.Repository;
using RESTAPIProject.Repository.IRepository.IVillaRepository;

namespace RESTAPIProject.Repository.VillaRepository
{
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {
        private readonly ApplicationDbContext _db;
        public VillaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Villa>> GetByNameAsync(string name)
        {
            IQueryable<Villa> query = _db.Villas;
            
            query = query.Where(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            
            return await query.ToListAsync();
        }


        public async Task UpdateAsync(Villa entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.Villas.Update(entity);
        }
    }
}