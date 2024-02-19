using AutoMapper;
using GoTravnikApi.Dto.RequestDto;
using GoTravnikApi.Dto.ResponseDto;
using GoTravnikApi.Exceptions;
using GoTravnikApi.IRepositories;
using GoTravnikApi.IServices;
using GoTravnikApi.Models;
using System.Runtime.CompilerServices;

namespace GoTravnikApi.Services
{
    public class EventService
        : TouristContentService<Event, EventDtoRequest, EventDtoResponse>, IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly IMapper _mapper;
        public EventService(IEventRepository eventRepository, ISubcategoryRepository subcategoryRepository,IMapper mapper) 
            : base(eventRepository, subcategoryRepository,mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<List<EventDtoResponse>> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                var eventResponseDtos = _mapper.Map<List<EventDtoResponse>>(await _eventRepository.FilterByDate(startDate, endDate));
                return eventResponseDtos;
            }
            catch (InternalServerErrorException)
            {
                throw;
            }
        }
    }
}
