namespace SchoolPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Generic : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Religions (ReligionName) VALUES ('Christian')");
            Sql("INSERT INTO Religions (ReligionName) VALUES ('Muslim')");
            Sql("INSERT INTO Tribes (TribeName) VALUES ('Igbo')");
            Sql("INSERT INTO Tribes (TribeName) VALUES ('Hausa')");
            Sql("INSERT INTO Tribes (TribeName) VALUES ('Yoruba')");
        }
        
        public override void Down()
        {
        }
    }
}
