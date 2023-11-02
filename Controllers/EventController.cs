using GoTravnikApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoTravnikApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<Event>>> Get() 
        {
            var events = new List<Event>
            {
                new Event
                {
                    Id = 1,
                    Title = "Test",
                    Description = "Test",
                }
            };
            return Ok(events);
        }
        
    }
}
