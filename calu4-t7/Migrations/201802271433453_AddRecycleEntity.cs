namespace calu4_t7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRecycleEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recycles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Units = c.Int(nullable: false),
                        DateStamp = c.DateTime(nullable: false),
                        SchoolClassId = c.Int(nullable: false),
                        RecycleTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RecycleTypes", t => t.RecycleTypeId, cascadeDelete: true)
                .ForeignKey("dbo.SchoolClasses", t => t.SchoolClassId, cascadeDelete: true)
                .Index(t => t.SchoolClassId)
                .Index(t => t.RecycleTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recycles", "SchoolClassId", "dbo.SchoolClasses");
            DropForeignKey("dbo.Recycles", "RecycleTypeId", "dbo.RecycleTypes");
            DropIndex("dbo.Recycles", new[] { "RecycleTypeId" });
            DropIndex("dbo.Recycles", new[] { "SchoolClassId" });
            DropTable("dbo.Recycles");
        }
    }
}
