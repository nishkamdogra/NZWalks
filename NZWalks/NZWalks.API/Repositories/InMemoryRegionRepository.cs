using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class InMemoryRegionRepository:IRegionRepository
    {
        public Task<Region> AddAsync(Region region)
        {
            throw new NotImplementedException();
        }

        public Task<Region> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            var regions = new List<Region>() 
            {
              new Region()
                {
                    Id=Guid.NewGuid(),
                    Name="Wellington",
                    Code="WLG",
                    Area=227755,
                    Lat=1.8822,
                    Long=299.88,
                    Population=500000
                },
                new Region()
                {
                    Id=Guid.NewGuid(),
                    Name="Auckland",
                    Code="AKL",
                    Area=227755,
                    Lat=1.8822,
                    Long=299.88,
                    Population=500000
                }
            };
            return regions;
        }

        public Task<Region> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Region> UpdateAsync(Guid id, Region region)
        {
            throw new NotImplementedException();
        }
    }
}
