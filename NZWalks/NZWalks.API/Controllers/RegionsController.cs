using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    //[Route("/Regions")]
    [Route("api/[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionsRepository;

        public RegionsController(IRegionRepository regionsRepository)
        {
            this.regionsRepository = regionsRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {

            var regions = regionsRepository.GetRegions();
            var regionsDto = new List<Models.DTO.Region>();
            //Map Region Domain Model to RegionDto
            regions.ToList().ForEach(region =>
            {
                var regionDto = new Models.DTO.Region()
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    Area = region.Area,
                    Lat = region.Lat,
                    Long = region.Long,
                    Population = region.Population,
                };
                regionsDto.Add(regionDto);
            });
            return Ok(regionsDto);
        }

    }
}
