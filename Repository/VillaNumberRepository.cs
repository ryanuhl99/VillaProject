using RESTAPIProject.Repository.IRepository;
using RESTAPIProject.Data.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Collections.Generic;
using RESTAPIProject.Models.Villa;
using RESTAPIProject.Repository.Repository;
using RESTAPIProject.Repository.IRepository.IVillaNumberRepository;
using RESTAPIProject.Models.VillaNumber;

namespace RESTAPIProject.Repository.VillaNumberRepository
{
    public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumberRepository
    {
        private readonly ApplicationDbContext _db;
        public VillaNumberRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<IEnumerable<VillaNumber>> GetByDetailsKeywordAsync(string details)
        {
            return await _db.VillaNumbers
                .Where(x => EF.Functions.Like(x.SpecialDetails, $"%{details}%"))
                .ToListAsync();
        }


        public async Task UpdateNumberAsync(VillaNumber entity)
        {
            _db.VillaNumbers.Update(entity);
        }

        public async Task CreateNumberAsync(VillaNumber entity)
        {
            var lastvillanum = await _db.VillaNumbers.OrderByDescending(x => x.VillaNo)
                                        .FirstOrDefaultAsync();

            int lastindex = (lastvillanum?.VillaNo ?? 99) + 1;

            entity.VillaNo = lastindex;

            await _db.VillaNumbers.AddAsync(entity);                                        
        }
    }
}