namespace Auction.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AuctionBids", "Profit", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.AuctionBids", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Auctions", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.AuctionItems", "StartPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.AuctionItems", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Bidders", "NameEn", c => c.String());
            AddColumn("dbo.Bidders", "NameAr", c => c.String());
            AddColumn("dbo.Bidders", "CreatedOn", c => c.DateTime(nullable: false));
            DropColumn("dbo.Auctions", "StartPrice");
            DropColumn("dbo.Bidders", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bidders", "Name", c => c.String());
            AddColumn("dbo.Auctions", "StartPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Bidders", "CreatedOn");
            DropColumn("dbo.Bidders", "NameAr");
            DropColumn("dbo.Bidders", "NameEn");
            DropColumn("dbo.AuctionItems", "CreatedOn");
            DropColumn("dbo.AuctionItems", "StartPrice");
            DropColumn("dbo.Auctions", "CreatedOn");
            DropColumn("dbo.AuctionBids", "CreatedOn");
            DropColumn("dbo.AuctionBids", "Profit");
        }
    }
}
