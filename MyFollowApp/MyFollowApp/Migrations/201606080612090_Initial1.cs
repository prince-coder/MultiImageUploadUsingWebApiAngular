namespace MyFollowApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyFollow",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        EmailId = c.String(),
                        Password = c.String(),
                        Street1 = c.String(),
                        Street2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        Pin = c.Int(nullable: false),
                        ContactNo = c.String(),
                        Roles = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateIndex("dbo.EndUsers", "UserId");
            CreateIndex("dbo.ProductOwners", "UserId");
            AddForeignKey("dbo.EndUsers", "UserId", "dbo.MyFollows", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.ProductOwners", "UserId", "dbo.MyFollows", "UserId", cascadeDelete: true);
           
   
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductOwners", "MyFollow_UserType", c => c.String());
            AddColumn("dbo.ProductOwners", "MyFollow_ContactNo", c => c.String());
            AddColumn("dbo.ProductOwners", "MyFollow_Pin", c => c.Int(nullable: false));
            AddColumn("dbo.ProductOwners", "MyFollow_Country", c => c.String());
            AddColumn("dbo.ProductOwners", "MyFollow_State", c => c.String());
            AddColumn("dbo.ProductOwners", "MyFollow_City", c => c.String());
            AddColumn("dbo.ProductOwners", "MyFollow_Street2", c => c.String());
            AddColumn("dbo.ProductOwners", "MyFollow_Street1", c => c.String());
            AddColumn("dbo.ProductOwners", "MyFollow_Password", c => c.String());
            AddColumn("dbo.ProductOwners", "MyFollow_EmailId", c => c.String());
            AddColumn("dbo.ProductOwners", "MyFollow_UserId", c => c.Int(nullable: false));
            AddColumn("dbo.EndUsers", "MyFollow_UserType", c => c.String());
            AddColumn("dbo.EndUsers", "MyFollow_ContactNo", c => c.String());
            AddColumn("dbo.EndUsers", "MyFollow_Pin", c => c.Int(nullable: false));
            AddColumn("dbo.EndUsers", "MyFollow_Country", c => c.String());
            AddColumn("dbo.EndUsers", "MyFollow_State", c => c.String());
            AddColumn("dbo.EndUsers", "MyFollow_City", c => c.String());
            AddColumn("dbo.EndUsers", "MyFollow_Street2", c => c.String());
            AddColumn("dbo.EndUsers", "MyFollow_Street1", c => c.String());
            AddColumn("dbo.EndUsers", "MyFollow_Password", c => c.String());
            AddColumn("dbo.EndUsers", "MyFollow_EmailId", c => c.String());
            AddColumn("dbo.EndUsers", "MyFollow_UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ProductOwners", "UserId", "dbo.MyFollows");
            DropForeignKey("dbo.EndUsers", "UserId", "dbo.MyFollows");
            DropIndex("dbo.ProductOwners", new[] { "UserId" });
            DropIndex("dbo.EndUsers", new[] { "UserId" });
            DropTable("dbo.MyFollows");
        }
    }
}
