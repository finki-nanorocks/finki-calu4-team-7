namespace calu4_t7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRecycleInsertUserFK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recycles", "ApplicationUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Recycles", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Recycles", "ApplicationUser_Id");
            AddForeignKey("dbo.Recycles", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recycles", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Recycles", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Recycles", "ApplicationUser_Id");
            DropColumn("dbo.Recycles", "ApplicationUserId");
        }
    }
}
