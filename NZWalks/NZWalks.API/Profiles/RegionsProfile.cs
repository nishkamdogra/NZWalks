using AutoMapper;

namespace NZWalks.API.Profiles
{
    public class RegionsProfile : Profile
    {
        public RegionsProfile()
        {
            CreateMap<Models.Domain.Region, Models.DTO.Region>()
                .ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id))
                .ForMember(dest => dest.Code, options => options.MapFrom(src => src.Code))
                .ForMember(dest => dest.Name, options => options.MapFrom(src => src.Name))
                .ForMember(dest => dest.Area, options => options.MapFrom(src => src.Area))
                .ForMember(dest => dest.Lat, options => options.MapFrom(src => src.Lat))
                .ForMember(dest => dest.Long, options => options.MapFrom(src => src.Long))
                .ForMember(dest => dest.Population, options => options.MapFrom(src => src.Population))
                .ReverseMap();
            CreateMap<Models.DTO.AddRegionRequest, Models.Domain.Region>()
                .ForMember(dest => dest.Code, options => options.MapFrom(src => src.Code))
                .ForMember(dest => dest.Name, options => options.MapFrom(src => src.Name))
                .ForMember(dest => dest.Area, options => options.MapFrom(src => src.Area))
                .ForMember(dest => dest.Lat, options => options.MapFrom(src => src.Lat))
                .ForMember(dest => dest.Lat, options => options.MapFrom(src => src.Lat))
                .ForMember(dest => dest.Population, options => options.MapFrom(src => src.Population))
                .ReverseMap();
            CreateMap<Models.DTO.UpdateRegionRequest, Models.Domain.Region>()
                .ForMember(dest => dest.Code, options => options.MapFrom(src => src.Code))
                .ForMember(dest => dest.Name, options => options.MapFrom(src => src.Name))
                .ForMember(dest => dest.Area, options => options.MapFrom(src => src.Area))
                .ForMember(dest => dest.Lat, options => options.MapFrom(src => src.Lat))
                .ForMember(dest => dest.Lat, options => options.MapFrom(src => src.Lat))
                .ForMember(dest => dest.Population, options => options.MapFrom(src => src.Population))
                .ReverseMap();
        }
    }
}
