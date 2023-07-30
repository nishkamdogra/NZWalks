﻿using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();
        Task<Region> GetByIdAsync(Guid id);
        Task<Region> AddAsync(Region region);
        Task<Region> UpdateAsync(Guid id, Region region);
        Task<Region> DeleteAsync(Guid id);
    }
}
