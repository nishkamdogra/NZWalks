using AutoMapper;

namespace NZWalks.API.Profiles
{
    public class WalkDifficultyProfile : Profile
    {

        public WalkDifficultyProfile()
        {
            CreateMap<Models.Domain.WalkDifficulty, Models.DTO.WalkDifficulty>()
                .ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id))
                .ForMember(dest => dest.Code, options => options.MapFrom(src => src.Code))
                .ReverseMap();
            CreateMap<Models.DTO.AddWalkDifficultyRequest, Models.Domain.WalkDifficulty>()
                .ForMember(dest => dest.Code, options => options.MapFrom(src => src.Code))
                .ReverseMap();
            CreateMap<Models.DTO.UpdateWalkDifficultyRequest, Models.Domain.WalkDifficulty>()
                .ForMember(dest => dest.Code, options => options.MapFrom(src => src.Code))
                .ReverseMap();
        }
    }
}
