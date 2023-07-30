using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class WalkDifficultyRepository:IWalkDifficultyRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;

        public WalkDifficultyRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<WalkDifficulty> AddDifficultyAsync(WalkDifficulty newDifficulty)
        {
            await nZWalksDbContext.WalkDifficulty.AddAsync(newDifficulty);
            await nZWalksDbContext.SaveChangesAsync();
            return newDifficulty;
        }

        public async Task<WalkDifficulty> GetDifficultyByIdAsync(Guid id)
        {
            var existingDifficulty=await nZWalksDbContext.WalkDifficulty.FirstOrDefaultAsync(x=>x.Id==id);
            return existingDifficulty;
        }

        public async Task<List<WalkDifficulty>> GetDifficultyListAsync()
        {
            return await nZWalksDbContext.WalkDifficulty.ToListAsync();
        }

        public async Task<WalkDifficulty> RemoveDifficultyAsync(Guid id)
        {
            var existingDifficulty = await nZWalksDbContext.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == id);
            if (existingDifficulty == null)
            {
                return null;
            }
            nZWalksDbContext.WalkDifficulty.Remove(existingDifficulty);
            await nZWalksDbContext.SaveChangesAsync() ;
            return existingDifficulty;
        }

        public async Task<WalkDifficulty> UpdateDifficultyAsync(Guid id, WalkDifficulty newDifficulty)
        {
            var existingDifficulty = await nZWalksDbContext.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == id);
            if (existingDifficulty == null)
            {
                return null;
            }
            existingDifficulty.Code = newDifficulty.Code;
            await nZWalksDbContext.SaveChangesAsync();
            return existingDifficulty;
        }
    }
}
