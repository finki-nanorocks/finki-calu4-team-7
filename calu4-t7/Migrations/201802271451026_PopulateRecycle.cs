namespace calu4_t7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateRecycle : DbMigration
    {
        public override void Up()
        {
            //POPULATING FOR THE FIRST 3 MONTHS
            //populating with recycle type 1
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(100, CAST('2017-12-01' AS DATETIME), 1, 1)");
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(120, CAST('2017-12-01' AS DATETIME), 2, 1)");
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(10, CAST('2017-12-01' AS DATETIME), 3, 1)");
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(50, CAST('2017-12-01' AS DATETIME), 4, 1)");
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(110, CAST('2017-12-01' AS DATETIME), 5, 1)");
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(200, CAST('2017-12-01' AS DATETIME), 6, 1)");
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(80, CAST('2017-12-01' AS DATETIME), 7, 1)");
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(90, CAST('2017-12-01' AS DATETIME), 8, 1)");
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(10, CAST('2017-12-01' AS DATETIME), 9, 1)");

            //populating with recycle type 2
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(10, CAST('2017-12-01' AS DATETIME), 1, 2)");
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(5, CAST('2017-12-01' AS DATETIME), 2, 2)");
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(0, CAST('2017-12-01' AS DATETIME), 3, 2)");
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(15, CAST('2017-12-01' AS DATETIME), 4, 2)");
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(0, CAST('2017-12-01' AS DATETIME), 5, 2)");
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(0, CAST('2017-12-01' AS DATETIME), 6, 2)");
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(0, CAST('2017-12-01' AS DATETIME), 7, 2)");
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(2, CAST('2017-12-01' AS DATETIME), 8, 2)");
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(3, CAST('2017-12-01' AS DATETIME), 9, 2)");

            //POPULATING FOR THE SECOND 3 MONTHS
            //populating with recycle type 1
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(80, CAST('2017-02-01' AS DATETIME), 1, 1)");
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(100, CAST('2017-02-01' AS DATETIME), 2, 1)");
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(100, CAST('2017-02-01' AS DATETIME), 3, 1)");
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(0, CAST('2017-02-01' AS DATETIME), 4, 1)");
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(10, CAST('2017-02-01' AS DATETIME), 5, 1)");
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(200, CAST('2017-02-01' AS DATETIME), 6, 1)");
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(120, CAST('2017-02-01' AS DATETIME), 7, 1)");
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(70, CAST('2017-02-01' AS DATETIME), 8, 1)");
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(110, CAST('2017-02-01' AS DATETIME), 9, 1)");

            //populating with recycle type 2
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(1, CAST('2017-02-01' AS DATETIME), 1, 2)");
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(5, CAST('2017-02-01' AS DATETIME), 2, 2)");
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(0, CAST('2017-02-01' AS DATETIME), 3, 2)");
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(5, CAST('2017-02-01' AS DATETIME), 4, 2)");
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(10, CAST('2017-02-01' AS DATETIME), 5, 2)");
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(1, CAST('2017-02-01' AS DATETIME), 6, 2)");
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(0, CAST('2017-02-01' AS DATETIME), 7, 2)");
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(3, CAST('2017-02-01' AS DATETIME), 8, 2)");
            Sql("INSERT INTO Recycles (Units, DateStamp, SchoolClassId, RecycleTypeId) VALUES(6, CAST('2017-02-01' AS DATETIME), 9, 2)");
        }
        
        public override void Down()
        {
        }
    }
}
