namespace calu4_t7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRecycleTypeEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecycleTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Points = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RecycleTypes");
        }
    }
}
