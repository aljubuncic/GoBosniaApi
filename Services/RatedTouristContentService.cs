using AutoMapper;
using GoTravnikApi.Dto.RequestDto;
using GoTravnikApi.Dto.ResponseDto;
using GoTravnikApi.Exceptions;
using GoTravnikApi.IRepositories;
using GoTravnikApi.IServices;
using GoTravnikApi.Models;
using GoTravnikApi.Repositories;

namespace GoTravnikApi.Services
{
    public class RatedTouristContentService<Entity, EntityRequestDto, EntityResponseDto>
        : TouristContentService<Entity, EntityRequestDto, EntityResponseDto>,
        IRatedTouristContentService<Entity, EntityRequestDto, EntityResponseDto>
        where Entity : RatedTouristContent
        where EntityRequestDto : RatedTouristContentDtoRequest
        where EntityResponseDto : RatedTouristContentDtoResponse
    {
        private readonly IRatedTouristContentRepository<Entity> _ratedTouristContentRepository;
        private readonly IMapper _mapper;
        public RatedTouristContentService(IRatedTouristContentRepository<Entity> ratedTouristContentRepository, ISubcategoryRepository subcategoryRepository, IMapper mapper) 
            : base(ratedTouristContentRepository, subcategoryRepository, mapper)
        {
            _ratedTouristContentRepository = ratedTouristContentRepository;
            _mapper = mapper;
        }

        public async Task<int> AddRating(int id, RatingDtoRequest ratingDtoRequest)
        {
            try
            {
                var ratedTouristContent = await _ratedTouristContentRepository.GetById(id) ?? throw new Exception($"Entity with id \'{id}\' does not exist in the database");
                var rating = _mapper.Map<Rating>(ratingDtoRequest);
                ratedTouristContent.Ratings.Add(rating);
                await _ratedTouristContentRepository.Update(ratedTouristContent);
                var ratingId = (await _ratedTouristContentRepository.GetById(id)).Ratings.OrderBy(x => x.Id).Last().Id; //maybe a better solution to be found?
                return ratingId;
            }
            catch (InternalServerErrorException)
            {
                throw;
            }
        }
    }
}
