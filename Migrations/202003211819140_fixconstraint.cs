namespace SchoolPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixconstraint : DbMigration
    {
        public override void Up()
        {
            Sql(@"ALTER TABLE [dbo].[Files] DROP CONSTRAINT [FK_dbo.Files_dbo.Students_Student_Id]");
        }
        
        public override void Down()
        {
        }
    }
}
