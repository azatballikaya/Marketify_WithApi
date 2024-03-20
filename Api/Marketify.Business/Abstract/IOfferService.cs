using Marketify.Business.DTOs.Response;
using Marketify.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketify.Business.Abstract
{
    public interface IOfferService
    {
        Task<Response> CreateOfferAsync(Offer offer);
        Task<Response<List<Offer>>> GetIncomingOffersAsync(string userId);
        Task<Response<List<Offer>>> GetMadeOffersAsync(string userId);
        
    }
}
