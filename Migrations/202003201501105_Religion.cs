namespace SchoolPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Religion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Religions",
                c => new
                    {
                        ReligionId = c.Int(nullable: false, identity: true),
                        ReligionName = c.String(),
                    })
                .PrimaryKey(t => t.ReligionId);
            
            AddColumn("dbo.Students", "ReligionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "ReligionId");
            AddForeignKey("dbo.Students", "ReligionId", "dbo.Religions", "ReligionId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "ReligionId", "dbo.Religions");
            DropIndex("dbo.Students", new[] { "ReligionId" });
            DropColumn("dbo.Students", "ReligionId");
            DropTable("dbo.Religions");
        }
    }
}
