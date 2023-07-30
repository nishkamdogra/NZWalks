using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NZWalks.API.Models.DTO
{
    public class AddWalkRequest
    {
        [Required]
        [MinLength (5)]
        [MaxLength (50)]
        public string Name { get; set; }
        [Required]
        [Range (1, 10)]
        public double Length { get; set; }
        [Required]
        [ForeignKey("Regions")]
        public Guid RegionId { get; set; }
        [Required]
        [ForeignKey("WalkDifficulty")]
        public Guid WalkDifficultyId { get; set; }
    }
}
