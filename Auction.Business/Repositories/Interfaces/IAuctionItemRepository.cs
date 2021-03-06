using Auction.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.Repositories.Interfaces
{
    public interface IAuctionItemRepository : IGenericRepository<AuctionItem>
    {
        IEnumerable<AuctionItem> GetAuctionItems();
    }
}
