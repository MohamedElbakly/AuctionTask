using Auction.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.ApplicationDBContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext():base("name=AuctionDBConnectionString")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Auction.DAL.Entities.Auction> Auctions { get; set; }
        public DbSet<AuctionBid> AuctionBids { get; set; }
        public DbSet<Bidder> Bidders { get; set; }
    }
}
