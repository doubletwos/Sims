namespace SchoolPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixReligion : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Religions (ReligionName) VALUES ('Christian')");
            Sql("INSERT INTO Religions (ReligionName) VALUES ('Muslim')");
        }
        
        public override void Down()
        {
        }
    }
}
