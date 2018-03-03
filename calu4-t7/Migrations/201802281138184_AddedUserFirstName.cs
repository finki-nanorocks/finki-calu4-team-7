namespace calu4_t7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserFirstName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "LastName");
        }
    }
}
