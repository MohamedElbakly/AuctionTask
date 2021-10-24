using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Entities
{
    public class AuctionItem : BaseEntity
    {
        public string Name { get; set; }
        public decimal StartPrice { get; set; }
    }
}
