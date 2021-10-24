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

        public override int SaveChanges()
        {
            updateEntitiesData();
            return base.SaveChanges();
        }


        public DbSet<Auction.DAL.Entities.Auction> Auctions { get; set; }
        public DbSet<AuctionBid> AuctionBids { get; set; }
        public DbSet<Bidder> Bidders { get; set; }

        public System.Data.Entity.DbSet<Auction.DAL.Entities.AuctionItem> AuctionItems { get; set; }


        void updateEntitiesData()
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = DateTime.Now;
                        break;
                    //case EntityState.Modified:
                    //    entry.Entity.CreatedOn = DateTime.Now;
                    //    break;
                }
            }
        }
    }
}
