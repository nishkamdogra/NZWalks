using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkDifficultyController : ControllerBase
    {
        private readonly IWalkDifficultyRepository difficultyRepository;
        private readonly IMapper mapper;

        public WalkDifficultyController(IWalkDifficultyRepository difficultyRepository, IMapper mapper)
        {
            this.difficultyRepository = difficultyRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetDifficultiesListAsync()
        {
            var difficulties= await difficultyRepository.GetDifficultyListAsync();
            var difficultiesDto = mapper.Map<List<Models.DTO.WalkDifficulty>>(difficulties);
            return Ok(difficultiesDto);
        }
        [HttpPost]
        public async Task<IActionResult> AddDifficultyAsync([FromBody] AddWalkDifficultyRequest addWalkDifficultyRequest)
        {
            var newDifficulty = mapper.Map<Models.Domain.WalkDifficulty>(addWalkDifficultyRequest);
            await difficultyRepository.AddDifficultyAsync(newDifficulty);
            return Ok(newDifficulty);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetDifficultyByIdAsync([FromRoute]Guid id)
        {
            var existingDifficulty=await difficultyRepository.GetDifficultyByIdAsync(id);
            if (existingDifficulty == null)
            {
                return NotFound($"{nameof(Models.DTO.WalkDifficulty)}.");
            }
            return Ok(existingDifficulty);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateDifficultyAsync([FromRoute] Guid id, [FromBody]UpdateWalkDifficultyRequest updateWalkDifficultyRequest)
        {
            var newDifficulty = mapper.Map<Models.Domain.WalkDifficulty>(updateWalkDifficultyRequest);
            var existingDifficulty=await difficultyRepository.UpdateDifficultyAsync(id, newDifficulty);
            if (existingDifficulty == null)
            {
                return NotFound($"{nameof(Models.DTO.WalkDifficulty)}.");
            }
            return Ok(existingDifficulty);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteDifficultyAsync([FromRoute] Guid id)
        {
            var deletedDifficulty = await difficultyRepository.RemoveDifficultyAsync(id);
            if (deletedDifficulty == null)
            {
                return NotFound($"{nameof(Models.DTO.WalkDifficulty)}.");
            }
            var deletedDifficultyDto=mapper.Map<Models.DTO.WalkDifficulty>(deletedDifficulty);
            return Ok(deletedDifficultyDto);
        }
    }
}
