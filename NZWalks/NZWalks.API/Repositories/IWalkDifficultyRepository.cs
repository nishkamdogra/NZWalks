using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IWalkDifficultyRepository
    {
        Task<List<WalkDifficulty>> GetDifficultyListAsync();
        Task<WalkDifficulty> GetDifficultyByIdAsync(Guid id);
        Task<WalkDifficulty>AddDifficultyAsync(WalkDifficulty newDifficulty);
        Task<WalkDifficulty>UpdateDifficultyAsync(Guid id, WalkDifficulty newDifficulty);
        Task<WalkDifficulty>RemoveDifficultyAsync(Guid id);
    }
}
