using AutoMapper;
using Marketify.Business.Abstract;
using Marketify.Business.DTOs;
using Marketify.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            IActionResult result = response.IsSuccess ? Ok(response.Data) : BadRequest();
            return result;
        }
        [HttpGet("GetMadeOffers/{id}")]

        public async Task<IActionResult> GetMadeOffers(string id)
        {
            var response = await _offerService.GetMadeOffersAsync(id);
            IActionResult result = response.IsSuccess ? Ok(response.Data) : BadRequest();
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
            IActionResult result = response.IsSuccess ? Ok(response.Data) : BadRequest();
            return result;

        }
    }
}
