using AutoMapper;
using GoTravnikApi.Dto.RequestDto;
using GoTravnikApi.Dto.ResponseDto;
using GoTravnikApi.IServices;
using GoTravnikApi.Models;
using GoTravnikApi.Repositories;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoTravnikApi.Controllers
{
    [Route("api/attractions")]
    [ApiController]
    public class AttractionController : TouristContentController<Attraction, AttractionDtoRequest, AttractionDtoResponse>
    {
        private readonly IAttractionService _attractionService;
        private readonly ISubcategoryService _subcategoryService;

        public AttractionController(IAttractionService attractionService, ISubcategoryService subcategoryService, IRatingService ratingService) 
            : base(attractionService, subcategoryService, ratingService, "attractions")
        {
            _attractionService = attractionService;
            _subcategoryService = subcategoryService;
        }
    }
}
