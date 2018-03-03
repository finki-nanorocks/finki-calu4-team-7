namespace calu4_t7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateRecycleTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO RecycleTypes (Name, Points) VALUES('Recycle Type 1', 1)");
            Sql("INSERT INTO RecycleTypes (Name, Points) VALUES('Recycle Type 2', 2)");
            Sql("INSERT INTO RecycleTypes (Name, Points) VALUES('Recycle Type 3', 3)");
            Sql("INSERT INTO RecycleTypes (Name, Points) VALUES('Recycle Type 4', 4)");
        }
        
        public override void Down()
        {
        }
    }
}
