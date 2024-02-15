using GoTravnikApi.Dto;
using GoTravnikApi.Exceptions;

using GoTravnikApi.IServices;
using GoTravnikApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoTravnikApi.Controllers
{
    [Route("api/locations")]
    [ApiController]
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;   
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService; 
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> AddLocation([FromBody] LocationDtoRequest locationDtoRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var locationId = await _locationService.Add(locationDtoRequest);
                return Created($"locations/{locationId}", "Succesfully added");
            }
            catch (InternalServerErrorException ex) 
            {
                return Problem
                    (statusCode: (int)ex.HttpStatusCode,
                    title: "Internal Server Error",
                    detail: ex.Message);
            }
        }
    }
}
