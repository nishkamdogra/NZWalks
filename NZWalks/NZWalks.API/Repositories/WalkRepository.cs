using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;

        public WalkRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<Walk> AddAsync(Walk walk)
        {
            await nZWalksDbContext.Walks.AddAsync(walk);
            await nZWalksDbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk> DeleteAsync(Guid id)
        {
            var walk= await nZWalksDbContext.Walks
                .Include(x=>x.WalkDifficulty).Include(x=>x.Region)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (walk == null)
            {
                return null;
            }
            nZWalksDbContext.Walks.Remove(walk);
            await nZWalksDbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await nZWalksDbContext.Walks.Include(x => x.WalkDifficulty).Include(x => x.Region).ToListAsync();
        }

        public async Task<Walk> GetAsync(Guid id)
        {
            return await nZWalksDbContext.Walks.Include(x=>x.WalkDifficulty).Include(x=>x.Region).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk=await nZWalksDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingWalk == null)
            {
                return null;
            }
            existingWalk.Name = walk.Name;
            existingWalk.Length = walk.Length;
            existingWalk.WalkDifficultyId = walk.WalkDifficultyId;
            existingWalk.RegionId = walk.RegionId;
            await nZWalksDbContext.SaveChangesAsync();
            return await nZWalksDbContext.Walks.Include(x=>x.WalkDifficulty).Include(x=>x.Region).FirstOrDefaultAsync(x => x.Id == id);

        }
    }
}
