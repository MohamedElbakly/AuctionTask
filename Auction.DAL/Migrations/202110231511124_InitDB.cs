namespace Auction.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuctionBids",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Bid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AuctionId = c.Int(),
                        BidderId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Auctions", t => t.AuctionId)
                .ForeignKey("dbo.Bidders", t => t.BidderId)
                .Index(t => t.AuctionId)
                .Index(t => t.BidderId);
            
            CreateTable(
                "dbo.Auctions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Item = c.String(),
                        StartPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Bidders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuctionBids", "BidderId", "dbo.Bidders");
            DropForeignKey("dbo.AuctionBids", "AuctionId", "dbo.Auctions");
            DropIndex("dbo.AuctionBids", new[] { "BidderId" });
            DropIndex("dbo.AuctionBids", new[] { "AuctionId" });
            DropTable("dbo.Bidders");
            DropTable("dbo.Auctions");
            DropTable("dbo.AuctionBids");
        }
    }
}
