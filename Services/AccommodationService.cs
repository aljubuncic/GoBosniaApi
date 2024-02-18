using AutoMapper;
using GoTravnikApi.Dto;
using GoTravnikApi.IRepositories;
using GoTravnikApi.IServices;
using GoTravnikApi.Models;

namespace GoTravnikApi.Services
{
    public class AccommodationService
        : RatedTouristContentService<Accommodation, AccommodationDtoRequest, AccommodationDtoResponse>, IAccommodationService
    {
        public AccommodationService(IAccommodationRepository accommodationRepository, ISubcategoryRepository subcategoryRepository, IMapper mapper) : base(accommodationRepository, subcategoryRepository, mapper)
        {
        }
    }
}
