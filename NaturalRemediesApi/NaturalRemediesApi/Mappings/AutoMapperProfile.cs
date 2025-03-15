using AutoMapper;
using NaturalRemediesApi.Models;
using NaturalRemediesApi.Models.Domain;
using NaturalRemediesApi.Models.DTO;

namespace NaturalRemediesApi.Mappings
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<NaturalRemedies, RemedyDto>();
            CreateMap<Diseases,RemediesDto>()
                .ForMember(dest => dest.Remedies,opt => opt.MapFrom(src => src.Remedies.Select(a => a.NaturalRemedies)));

            CreateMap<HealthTips, TipsResponseDto>();
            CreateMap<Diseases, HealthTipsResponseDto>()
                .ForMember(dest => dest.Tips, opt => opt.MapFrom(src => src.HealthTips));

            CreateMap<Products, ProductsResponseDto>();

        }
    }
}
