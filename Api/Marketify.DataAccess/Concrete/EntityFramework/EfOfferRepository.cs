using Marketify.DataAccess.Abstract;
using Marketify.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketify.DataAccess.Concrete.EntityFramework
{
    public class EfOfferRepository:GenericRepository<Offer>,IOfferDal
    {
        private readonly IdentityContext _context;

        public EfOfferRepository(IdentityContext context):base(context)
        {
            _context = context;
        }
    }
}
