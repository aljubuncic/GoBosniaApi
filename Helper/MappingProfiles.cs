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

            CreateMap<Accommodation, AccommodationDto>();
            CreateMap<AccommodationDto, Accommodation>();

            CreateMap<RatingDto, Rating>();
            CreateMap<Rating, RatingDto>();
            
            CreateMap<TouristContent, TouristContentDto>();
            CreateMap<TouristContentDto, TouristContent>();

            CreateMap<Attraction, AttractionDto>();
            CreateMap<AttractionDto, Attraction>();

            CreateMap<Activity, ActivityDto>();
            CreateMap<ActivityDto, Activity>();

            CreateMap<Event, EventDto>();
            CreateMap<EventDto, Event>();

            CreateMap<FoodAndDrink, FoodAndDrinkDto>();
            CreateMap<FoodAndDrinkDto, FoodAndDrink>();

            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();
        }
    }
}
