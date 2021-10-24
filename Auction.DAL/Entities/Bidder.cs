﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Entities
{
    public class Bidder: BaseEntity
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }
    }
}
