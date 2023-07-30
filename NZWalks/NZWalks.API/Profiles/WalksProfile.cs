using AutoMapper;

namespace NZWalks.API.Profiles
{
    public class WalksProfile : Profile
    {
        public WalksProfile()
        {
            CreateMap<Models.Domain.Walk, Models.DTO.Walk>()
                .ReverseMap();

            CreateMap<Models.Domain.WalkDifficulty, Models.DTO.WalkDifficulty>()
                .ReverseMap();
            CreateMap<Models.DTO.AddWalkRequest, Models.Domain.Walk>()
                .ForMember(dest=>dest.Name,options=>options.MapFrom(src=>src.Name))
                .ForMember(dest => dest.Length, options => options.MapFrom(src => src.Length))
                .ForMember(dest => dest.WalkDifficultyId, options => options.MapFrom(src => src.WalkDifficultyId))
                .ForMember(dest => dest.RegionId, options => options.MapFrom(src => src.RegionId))
                .ReverseMap();
            CreateMap<Models.DTO.UpdateWalkRequest, Models.Domain.Walk>()
               .ForMember(dest => dest.Name, options => options.MapFrom(src => src.Name))
               .ForMember(dest => dest.Length, options => options.MapFrom(src => src.Length))
               .ForMember(dest => dest.WalkDifficultyId, options => options.MapFrom(src => src.WalkDifficultyId))
               .ForMember(dest => dest.RegionId, options => options.MapFrom(src => src.RegionId))
               .ReverseMap();
        }
    }
}
