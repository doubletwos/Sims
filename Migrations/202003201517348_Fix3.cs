namespace SchoolPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "ReligionId", "dbo.Religions");
            DropForeignKey("dbo.Students", "TribeId", "dbo.Tribes");
            DropIndex("dbo.Students", new[] { "ReligionId" });
            DropIndex("dbo.Students", new[] { "TribeId" });
            DropColumn("dbo.Students", "ReligionId");
            DropColumn("dbo.Students", "TribeId");
            DropTable("dbo.Religions");
            DropTable("dbo.Tribes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tribes",
                c => new
                    {
                        TribeId = c.Int(nullable: false, identity: true),
                        TribeName = c.String(),
                    })
                .PrimaryKey(t => t.TribeId);
            
            CreateTable(
                "dbo.Religions",
                c => new
                    {
                        ReligionId = c.Int(nullable: false, identity: true),
                        ReligionName = c.String(),
                    })
                .PrimaryKey(t => t.ReligionId);
            
            AddColumn("dbo.Students", "TribeId", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "ReligionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "TribeId");
            CreateIndex("dbo.Students", "ReligionId");
            AddForeignKey("dbo.Students", "TribeId", "dbo.Tribes", "TribeId", cascadeDelete: true);
            AddForeignKey("dbo.Students", "ReligionId", "dbo.Religions", "ReligionId", cascadeDelete: true);
        }
    }
}
