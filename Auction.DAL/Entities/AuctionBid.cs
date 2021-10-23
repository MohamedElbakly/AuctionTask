using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Entities
{
    public class AuctionBid
    {
        [Key]
        public int ID { get; set; }
        public decimal Bid { get; set; }

        [ForeignKey("Auction")]
        public Nullable<int> AuctionId { get; set; }
        public virtual Auction Auction { get; set; }

        [ForeignKey("Bidder")]
        public Nullable<int> BidderId { get; set; }
        public virtual Bidder Bidder { get; set; }
    }
}
