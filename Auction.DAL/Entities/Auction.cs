using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Entities
{
    public class Auction: BaseEntity
    {
        public Auction()
        {
            this.AuctionBids = new HashSet<AuctionBid>();
        }

        [ForeignKey("AuctionItem")]
        public Nullable<int> AuctionItemId { get; set; }
        public virtual AuctionItem AuctionItem { get; set; }


        public virtual ICollection<AuctionBid> AuctionBids { get; set; }
    }
}
