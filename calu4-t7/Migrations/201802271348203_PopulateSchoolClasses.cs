namespace calu4_t7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateSchoolClasses : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO SchoolClasses (Name, SchoolId) VALUES('Class 1.1', 1)");
            Sql("INSERT INTO SchoolClasses (Name, SchoolId) VALUES('Class 2.1', 1)");
            Sql("INSERT INTO SchoolClasses (Name, SchoolId) VALUES('Class 3.1', 1)");
            Sql("INSERT INTO SchoolClasses (Name, SchoolId) VALUES('Class 4.1', 1)");
            Sql("INSERT INTO SchoolClasses (Name, SchoolId) VALUES('Class 5.1', 1)");
            Sql("INSERT INTO SchoolClasses (Name, SchoolId) VALUES('Class 1.2', 2)");
            Sql("INSERT INTO SchoolClasses (Name, SchoolId) VALUES('Class 2.2', 2)");
            Sql("INSERT INTO SchoolClasses (Name, SchoolId) VALUES('Class 3.2', 2)");
            Sql("INSERT INTO SchoolClasses (Name, SchoolId) VALUES('Class 4.2', 2)");
        }
        
        public override void Down()
        {
        }
    }
}
