namespace SchoolPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeacherUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Teachers", "EmploymentStartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Teachers", "HouseNumberOrName", c => c.String(nullable: false));
            AddColumn("dbo.Teachers", "FirstLineofAdd", c => c.String(nullable: false));
            AddColumn("dbo.Teachers", "SecondLineofAdd", c => c.String(nullable: false));
            AddColumn("dbo.Teachers", "Area", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "Area");
            DropColumn("dbo.Teachers", "SecondLineofAdd");
            DropColumn("dbo.Teachers", "FirstLineofAdd");
            DropColumn("dbo.Teachers", "HouseNumberOrName");
            DropColumn("dbo.Teachers", "EmploymentStartDate");
            DropColumn("dbo.Teachers", "DateOfBirth");
        }
    }
}
