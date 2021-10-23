namespace Auction.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAuctionItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuctionItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Auctions", "AuctionItemId", c => c.Int());
            CreateIndex("dbo.Auctions", "AuctionItemId");
            AddForeignKey("dbo.Auctions", "AuctionItemId", "dbo.AuctionItems", "ID");
            DropColumn("dbo.Auctions", "Item");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Auctions", "Item", c => c.String());
            DropForeignKey("dbo.Auctions", "AuctionItemId", "dbo.AuctionItems");
            DropIndex("dbo.Auctions", new[] { "AuctionItemId" });
            DropColumn("dbo.Auctions", "AuctionItemId");
            DropTable("dbo.AuctionItems");
        }
    }
}
