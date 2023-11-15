using AutoMapper;
using GoTravnikApi.Dto;
using GoTravnikApi.Models;

namespace GoTravnikApi.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Subcategory, SubcategoryDto>();
            CreateMap<Accommodation, AccommodationDto>();
            CreateMap<RatingDto, Rating>();
        }
    }
}
