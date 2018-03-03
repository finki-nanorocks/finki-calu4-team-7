namespace calu4_t7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSchoolClassEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SchoolClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SchoolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.SchoolId, cascadeDelete: true)
                .Index(t => t.SchoolId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SchoolClasses", "SchoolId", "dbo.Schools");
            DropIndex("dbo.SchoolClasses", new[] { "SchoolId" });
            DropTable("dbo.SchoolClasses");
        }
    }
}
