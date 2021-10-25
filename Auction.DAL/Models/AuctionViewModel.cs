using Auction.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Models
{
    public class AuctionViewModel
    {
        public int AuctionID { get; set; }
        public string AuctionItemName { get; set; }
        public decimal AuctionItemPrice { get; set; }
        public decimal Bid { get; set; }
        public IEnumerable<Bidder> BidderId { get; set; }

    }
}
