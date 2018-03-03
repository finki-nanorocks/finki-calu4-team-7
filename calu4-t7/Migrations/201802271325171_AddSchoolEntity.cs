namespace calu4_t7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSchoolEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Name = c.String(),
                        Municiplaity = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Schools");
        }
    }
}
