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
            CreateMap<SubcategoryDto, Subcategory>();

            CreateMap<Accommodation, AccommodationDtoResponse>();
            CreateMap<AccommodationDtoResponse, Accommodation>();
            CreateMap<Accommodation, AccommodationDtoRequest>();
            CreateMap<AccommodationDtoRequest, Accommodation>();

            CreateMap<RatingDtoResponse, Rating>();
            CreateMap<Rating, RatingDtoResponse>();
            CreateMap<RatingDtoRequest, Rating>();
            CreateMap<Rating, RatingDtoRequest>();

            CreateMap<TouristContent, TouristContentDtoResponse>();
            CreateMap<TouristContentDtoResponse, TouristContent>();
            CreateMap<TouristContent, TouristContentDtoRequest>();
            CreateMap<TouristContentDtoRequest, TouristContent>();

            CreateMap<Attraction, AttractionDtoResponse>();
            CreateMap<AttractionDtoResponse, Attraction>();
            CreateMap<Attraction, AttractionDtoRequest>();
            CreateMap<AttractionDtoRequest, Attraction>();

            CreateMap<Activity, ActivityDtoResponse>();
            CreateMap<ActivityDtoResponse, Activity>();
            CreateMap<Activity, ActivityDtoRequest>();
            CreateMap<ActivityDtoRequest, Activity>();

            CreateMap<Event, EventDtoResponse>();
            CreateMap<EventDtoResponse, Event>();
            CreateMap<Event, EventDtoRequest>();
            CreateMap<EventDtoRequest, Event>();

            
        }
    }
}
