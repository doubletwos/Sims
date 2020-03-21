namespace SchoolPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Generic : DbMigration
    {
        public override void Up()
        {
          
            Sql("INSERT INTO Genders (Name) VALUES ('MALE')");
            Sql("INSERT INTO Genders (Name) VALUES ('FEMALE')");


           
            Sql("INSERT INTO Titles (TitleName) VALUES ('Mr')");
            Sql("INSERT INTO Titles (TitleName) VALUES ('Mrs')");
            Sql("INSERT INTO Titles (TitleName) VALUES ('Ms')");
            Sql("INSERT INTO Titles (TitleName) VALUES ('Miss')");



          
            Sql("INSERT INTO Years (YearNumber,YearName) VALUES ('1','Primary 1')");
            Sql("INSERT INTO Years (YearNumber,YearName) VALUES ('2','Primary 2')");
            Sql("INSERT INTO Years (YearNumber,YearName) VALUES ('3','Primary 3')");
            Sql("INSERT INTO Years (YearNumber,YearName) VALUES ('4','Primary 4')");
            Sql("INSERT INTO Years (YearNumber,YearName) VALUES ('5','Primary 5')");
            Sql("INSERT INTO Years (YearNumber,YearName) VALUES ('6','Primary 6')");


           
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
