using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Entities
{
    public class Auction
    {
        public Auction()
        {
            this.AuctionBids = new HashSet<AuctionBid>();
        }
        [Key]
        public int ID { get; set; }

        [ForeignKey("AuctionItem")]
        public Nullable<int> AuctionItemId { get; set; }
        public virtual AuctionItem AuctionItem { get; set; }

        public decimal StartPrice { get; set; }

        public virtual ICollection<AuctionBid> AuctionBids { get; set; }
    }
}
