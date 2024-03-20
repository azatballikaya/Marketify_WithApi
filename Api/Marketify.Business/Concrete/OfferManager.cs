using Marketify.Business.Abstract;
using Marketify.Business.DTOs.Response;
using Marketify.DataAccess.Abstract;
using Marketify.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketify.Business.Concrete
{
    public class OfferManager : IOfferService
    {
        private readonly IOfferDal _offerDal;
        private readonly IPostDal _postDal;

        public OfferManager(IOfferDal offerDal, IPostDal postDal)
        {
            _offerDal = offerDal;
            _postDal = postDal;
        }

        public async Task<Response> CreateOfferAsync(Offer offer)
        {

            var post=await _postDal.GetAsync(x=>x.Id==offer.PostId);
            if(post.UserId==offer.UserId)
            {
                return Response.Fail();
            }
            await _offerDal.InsertAsync(offer);
            return Response.Success();
        }

        public async Task<Response<List<Offer>>> GetMadeOffersAsync(string userId)
        {
            var offers=await _offerDal.GetAllAsync(x=>x.UserId==userId,x=>x.Include(z=>z.User).Include(y=>y.Post));
            if (offers != null)
            {
                return Response<List<Offer>>.Success(offers);
            }
            return Response<List<Offer>>.Fail();
        }

        public async Task<Response<List<Offer>>> GetIncomingOffersAsync(string userId)
        {
            var offers=await _offerDal.GetAllAsync(x=>x.Post.UserId==userId,x=>x.Include(z=>z.User).Include(y=>y.Post));
            if(offers != null)
            {
                return Response<List<Offer>>.Success(offers);
            }
            return Response<List<Offer>>.Fail();

        }
    }
}
