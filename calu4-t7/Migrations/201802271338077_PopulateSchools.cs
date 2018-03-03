namespace calu4_t7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateSchools : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Schools (Address, Name, Municiplaity) VALUES('Adress 1', 'Name 1', 'Municipality 1')");
            Sql("INSERT INTO Schools (Address, Name, Municiplaity) VALUES('Adress 2', 'Name 2', 'Municipality 2')");
        }
        
        public override void Down()
        {
        }
    }
}
