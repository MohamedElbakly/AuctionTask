using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Entities
{
    public class AuctionBid: BaseEntity
    {
        public AuctionBid()
        {
            //this.Profit = this.Auction.AuctionItem.StartPrice - this.Bid;
        }
        public decimal Bid { get; set; }
        public decimal Profit { get; set; }

        [ForeignKey("Auction")]
        public Nullable<int> AuctionId { get; set; }
        public virtual Auction Auction { get; set; }

        [ForeignKey("Bidder")]
        public Nullable<int> BidderId { get; set; }
        public virtual Bidder Bidder { get; set; }
    }
}
