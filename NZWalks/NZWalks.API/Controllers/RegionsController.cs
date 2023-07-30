using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    //[Route("/Regions")]
    [Route("api/[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionsRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionsRepository, IMapper mapper)
        {
            this.regionsRepository = regionsRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRegionsAsync()
        {

            var regions = await regionsRepository.GetAllAsync();
            //var regionsDto = new List<Models.DTO.Region>();
            //Map Region Domain Model to RegionDto
            /*regions.ToList().ForEach(region =>
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
            });*/
            var regionsDto = mapper.Map<List<Models.DTO.Region>>(regions);
            return Ok(regionsDto);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetRegionAsync([FromRoute]Guid id)
        {
            var region= await regionsRepository.GetByIdAsync(id);
            if (region==null)
            {
                return NotFound();
            }
            var regionDto=mapper.Map<Models.DTO.Region>(region);
            return Ok(regionDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegionAsync([FromBody]AddRegionRequest addRegionRequest)
        {
            var region=mapper.Map<Models.Domain.Region>(addRegionRequest);
            await regionsRepository.AddAsync(region);
            var regionDto = mapper.Map<Models.DTO.Region>(region);
            return Ok(regionDto);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute]Guid id, [FromBody]UpdateRegionRequest updateRegionRequest)
        {
            var region=mapper.Map<Models.Domain.Region>(updateRegionRequest);
            region = await regionsRepository.UpdateAsync(id, region);
            if (region==null)
            {
                return NotFound();
            }
            var regionDto=mapper.Map<Models.DTO.Region>(region);
            return Ok(regionDto);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteRegionAsync([FromRoute]Guid id)
        {
            var region = await regionsRepository.DeleteAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            var regionDto = mapper.Map<Models.DTO.Region>(region);
            return Ok(regionDto);
        }

    }
}
