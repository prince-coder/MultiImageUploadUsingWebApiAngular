namespace MyFollowApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial11 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EndUsers", newName: "EndUser");
            RenameTable(name: "dbo.MyFollows", newName: "MyFollows");
            RenameTable(name: "dbo.ProductOwners", newName: "ProductOwner");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ProductOwner", newName: "ProductOwners");
            RenameTable(name: "dbo.MyFollow", newName: "MyFollows");
            RenameTable(name: "dbo.EndUser", newName: "EndUsers");
        }
    }
}
