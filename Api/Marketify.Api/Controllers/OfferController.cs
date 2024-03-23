using AutoMapper;
using Marketify.Business.Abstract;
using Marketify.Business.DTOs;
using Marketify.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Marketify.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _offerService;
        private readonly IMapper _mapper;

        public OfferController(IOfferService offerService, IMapper mapper)
        {
            _offerService = offerService;
            _mapper = mapper;
        }
        [HttpGet("GetIncomingOffers/{id}")]
        
        public async Task<IActionResult> GetIncomingOffers(string id)
        {
            var response=await _offerService.GetIncomingOffersAsync(id);
            var jsonData = response.IsSuccess ? JsonConvert.SerializeObject(response.Data, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            }) : null;
            IActionResult result = jsonData!=null ? Ok(jsonData) : BadRequest();
            return result;
        }
        [HttpGet("GetMadeOffers/{id}")]

        public async Task<IActionResult> GetMadeOffers(string id)
        {
            var response = await _offerService.GetMadeOffersAsync(id);
            var jsonData = response.IsSuccess ? JsonConvert.SerializeObject(response.Data, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            }) : null;
            IActionResult result = jsonData != null ? Ok(jsonData) : BadRequest();
            return result;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOffer(CreateOfferDTO createOfferDTO)
        {
            
            var offer = _mapper.Map<Offer>(createOfferDTO);
            var response=await _offerService.CreateOfferAsync(offer);
            IActionResult result = response.IsSuccess ? Ok() : BadRequest();
            return result;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOffer(int id)
        {
            var response=await _offerService.GetOfferAsync(id);
            var jsonData = response.IsSuccess ? JsonConvert.SerializeObject(response.Data, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            }) : null;
            IActionResult result = response.IsSuccess ? Ok(jsonData) : BadRequest();
            return result;

        }
    }
}
