using RESTAPIProject.Repository.IRepository;
using RESTAPIProject.Data.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Collections.Generic;
using RESTAPIProject.Models.Villa;
using RESTAPIProject.Repository.Repository;
using RESTAPIProject.Repository.IRepository.IVillaNumberRepository;

namespace RESTAPIProject.Repository.VillaRepository
{
    public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumberRepository
    {
        private readonly ApplicationDbContext _db;
        public VillaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<IEnumerable<VillaNumber>> GetByDetailsKeywordAsync(string details)
        {
            return await _db.VillaNumbers
                .Where(x => EF.Functions.Like(x.SpecialDetails, $"%{details}%"))
                .ToListAsync();
        }


        public async Task UpdateAsync(VillaNumber entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.VillaNumbers.Update(entity);
        }
    }
}