using RESTAPIProject.Repository.IRepository;
using RESTAPIProject.Data.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Collections.Generic;
using RESTAPIProject.Models.Villa;

namespace RESTAPIProject.Repository.Repository
{
    public class VillaRepository : IVillaRepository
    {
        private readonly ApplicationDbContext _db;
        public VillaRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Villa>> GetAllAsync(Expression<Func<Villa, bool>> filter = null)
        {
            IQueryable<Villa> query = _db.Villas;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public async Task<Villa> GetByIdAsync(int id)
        {
            return await _db.Villas.FindAsync(id);
        }

        public async Task<IEnumerable<Villa>> GetByNameAsync(string name)
        {
            IQueryable<Villa> query = _db.Villas;
            
            query = query.Where(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            
            return await query.ToListAsync();
        }

        public async Task CreateAsync(Villa entity)
        {
            await _db.Villas.AddAsync(entity);
        }

        public async Task UpdateAsync(Villa entity)
        {
            _db.Villas.Update(entity);
        }

        public Task RemoveAsync(Villa entity)
        {
            _db.Villas.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}