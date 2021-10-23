using Auction.Business.Repositories.Interfaces;
using Auction.DAL.ApplicationDBContext;
using Auction.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.Repositories
{
    public class BidderRepository : GenericRepository<Bidder>, IBidderRepository
    {
        public BidderRepository(IUnitOfWork<ApplicationDBContext> unitOfWork) : base(unitOfWork)
        {

        }

        public BidderRepository(ApplicationDBContext context) : base(context)
        {

        }

        public IEnumerable<Bidder> GetBidders()
        {
            return Context.Bidders.ToList();
        }
    }
}
