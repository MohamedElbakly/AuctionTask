using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Entities
{
    public class BaseEntity
    {
        [Key]
        public int ID { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
