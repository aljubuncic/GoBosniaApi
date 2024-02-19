using AutoMapper;
using GoTravnikApi.Dto.RequestDto;
using GoTravnikApi.Dto.ResponseDto;
using GoTravnikApi.Models;

namespace GoTravnikApi.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Subcategory, SubcategoryDtoRequest>().ReverseMap();
            CreateMap<Subcategory, SubcategoryDtoResponse>().ReverseMap();

            CreateMap<Accommodation, AccommodationDtoResponse>().ReverseMap();
            CreateMap<Accommodation, AccommodationDtoRequest>().ReverseMap();

            CreateMap<Rating, RatingDtoResponse>().ReverseMap();
            CreateMap<Rating, RatingDtoRequest>().ReverseMap();

            CreateMap<TouristContent, TouristContentDtoResponse>().ReverseMap();
            CreateMap<TouristContent, TouristContentDtoRequest>().ReverseMap();

            CreateMap<Attraction, AttractionDtoResponse>().ReverseMap();
            CreateMap<Attraction, AttractionDtoRequest>().ReverseMap();

            CreateMap<Activity, ActivityDtoResponse>().ReverseMap();
            CreateMap<Activity, ActivityDtoRequest>().ReverseMap();

            CreateMap<Event, EventDtoResponse>().ReverseMap();
            CreateMap<Event, EventDtoRequest>().ReverseMap();

            CreateMap<FoodAndDrink, FoodAndDrinkDtoResponse>().ReverseMap();
            CreateMap<FoodAndDrink, FoodAndDrinkDtoRequest>().ReverseMap();

            CreateMap<Post, PostDtoResponse>().ReverseMap();
            CreateMap<Post, PostDtoRequest>().ReverseMap();

            CreateMap<Location, LocationDtoResponse>().ReverseMap();
            CreateMap<Location, LocationDtoRequest>().ReverseMap();

            CreateMap<Image, ImageDtoResponse>().ReverseMap();  
            CreateMap<Image, ImageDtoRequest>().ReverseMap();  
        }
    }
}
