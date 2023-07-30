using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllWaksAsync()
        {
            var walks = await walkRepository.GetAllAsync();
            var walksDto = mapper.Map<List<Models.DTO.Walk>>(walks);
            return Ok(walksDto);
        }
        [HttpPost]
        public async Task<IActionResult> AddWalkAsync([FromBody] AddWalkRequest addWalkRequest)
        {
            var walk = mapper.Map<Models.Domain.Walk>(addWalkRequest);
            await walkRepository.AddAsync(walk);
            return Ok(walk);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetWalkAsync([FromRoute] Guid id)
        {
            var walk = await walkRepository.GetAsync(id);
            if (walk == null)
            {
                return NotFound();
            }
            var regionDto = mapper.Map<Models.DTO.Walk>(walk);
            return Ok(regionDto);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateWalkAsync([FromRoute]Guid id,UpdateWalkRequest updateWalkRequest)
        {
            var walk = mapper.Map<Models.Domain.Walk>(updateWalkRequest);
            walk = await walkRepository.UpdateAsync(id, walk);
            if (walk == null)
            {
                return NotFound(walk);
            }
            var walkDto=mapper.Map<Models.DTO.Walk>(walk);
            return Ok(walkDto);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteWalkAsync([FromRoute]Guid id)
        {
            var walk= await walkRepository.DeleteAsync(id);
            if (walk == null)
            {
                return NotFound($"{nameof(Walk)}.");
            }
            return Ok(walk);
        }

    }
}
