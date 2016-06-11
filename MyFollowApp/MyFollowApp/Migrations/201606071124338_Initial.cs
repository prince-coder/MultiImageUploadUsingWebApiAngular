namespace MyFollowApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EndUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Gender = c.Boolean(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        MyFollow_UserId = c.Int(nullable: false),
                        MyFollow_EmailId = c.String(),
                        MyFollow_Password = c.String(),
                        MyFollow_Street1 = c.String(),
                        MyFollow_Street2 = c.String(),
                        MyFollow_City = c.String(),
                        MyFollow_State = c.String(),
                        MyFollow_Country = c.String(),
                        MyFollow_Pin = c.Int(nullable: false),
                        MyFollow_ContactNo = c.String(),
                        MyFollow_UserType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductOwners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CompanyName = c.String(),
                        Description = c.String(),
                        DateOfJoining = c.DateTime(nullable: false),
                        FoundedIn = c.Int(nullable: false),
                        WebsiteURL = c.String(),
                        TwitterHandler = c.String(),
                        FacebookPageURL = c.String(),
                        MyFollow_UserId = c.Int(nullable: false),
                        MyFollow_EmailId = c.String(),
                        MyFollow_Password = c.String(),
                        MyFollow_Street1 = c.String(),
                        MyFollow_Street2 = c.String(),
                        MyFollow_City = c.String(),
                        MyFollow_State = c.String(),
                        MyFollow_Country = c.String(),
                        MyFollow_Pin = c.Int(nullable: false),
                        MyFollow_ContactNo = c.String(),
                        MyFollow_UserType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductOwners");
            DropTable("dbo.EndUsers");
        }
    }
}
