using GoTravnikApi.Data;
using GoTravnikApi.Dto;
using GoTravnikApi.IRepositories;
using GoTravnikApi.Models;
using GoTravnikApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GoTravnikApi.Repositories
{
    public class AccommodationRepository : TouristContentRepository<Accommodation>, IAccommodationRepository
    {
        public AccommodationRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
