using GoTravnikApi.Dto;
using GoTravnikApi.Models;

namespace GoTravnikApi.IServices
{
    public interface IEventService : ITouristContentService<Event, EventDtoRequest, EventDtoResponse>
    {
        public Task<List<EventDtoResponse>> GetByDateRange(DateTime startDate, DateTime endDate);
    }
}
