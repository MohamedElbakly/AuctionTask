using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Entities
{
    public class AuctionItem
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
