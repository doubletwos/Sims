namespace SchoolPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tribe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tribes",
                c => new
                    {
                        TribeId = c.Int(nullable: false, identity: true),
                        TribeName = c.String(),
                    })
                .PrimaryKey(t => t.TribeId);
            
            AddColumn("dbo.Students", "TribeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "TribeId");
            AddForeignKey("dbo.Students", "TribeId", "dbo.Tribes", "TribeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "TribeId", "dbo.Tribes");
            DropIndex("dbo.Students", new[] { "TribeId" });
            DropColumn("dbo.Students", "TribeId");
            DropTable("dbo.Tribes");
        }
    }
}
