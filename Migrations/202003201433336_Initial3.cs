namespace SchoolPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial3 : DbMigration
    {
        public override void Up()
        {
            //DropColumn("dbo.Students", "ReligionId");
            //DropColumn("dbo.Students", "TribeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "TribeId", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "ReligionId", c => c.Int(nullable: false));
        }
    }
}
