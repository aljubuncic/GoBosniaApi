using AutoMapper;
using GoTravnikApi.Dto;
using GoTravnikApi.Exceptions;
using GoTravnikApi.IRepositories;
using GoTravnikApi.IServices;
using GoTravnikApi.Models;

namespace GoTravnikApi.Services
{
    public class RatingService: Service<Rating, RatingDtoRequest, RatingDtoResponse>, IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;
        public RatingService(IRatingRepository ratingRepository, IMapper mapper): base(ratingRepository, mapper)
        { 
            _ratingRepository = ratingRepository;   
        }

        public async Task ApproveRating(int id)
        {
            var rating = await _ratingRepository.GetById(id) ?? throw new NotFoundException("Entity does not exist in the database");
            rating.Approved = true;
            try
            {
                await _ratingRepository.Update(rating);
            }
            catch(InternalServerErrorException) 
            {
                throw;
            }
        }
    }
}
