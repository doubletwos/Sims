namespace SchoolPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        ContentType = c.String(),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 12),
                        MiddleName = c.String(maxLength: 12),
                        Lastname = c.String(nullable: false, maxLength: 12),
                        DateOfBirth = c.DateTime(nullable: false),
                        EnrolmentDate = c.DateTime(nullable: false),
                        HouseNumberOrName = c.String(nullable: false),
                        FirstLineofAdd = c.String(nullable: false),
                        SecondLineofAdd = c.String(nullable: false),
                        Area = c.String(nullable: false),
                        FileId = c.Int(nullable: false),
                        ReligionId = c.Int(nullable: false),
                        TribeId = c.Int(nullable: false),
                        YearId = c.Int(nullable: false),
                        GenderId = c.Int(nullable: false),
                        TeacherId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genders", t => t.GenderId, cascadeDelete: true)
                .ForeignKey("dbo.Religions", t => t.ReligionId, cascadeDelete: true)
                .ForeignKey("dbo.Years", t => t.YearId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .ForeignKey("dbo.Tribes", t => t.TribeId, cascadeDelete: true)
                .Index(t => t.ReligionId)
                .Index(t => t.TribeId)
                .Index(t => t.YearId)
                .Index(t => t.GenderId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        GenderId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GenderId);
            
            CreateTable(
                "dbo.Religions",
                c => new
                    {
                        ReligionId = c.Int(nullable: false, identity: true),
                        ReligionName = c.String(),
                    })
                .PrimaryKey(t => t.ReligionId);
            
            CreateTable(
                "dbo.StudentsSubjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Scores = c.Int(),
                        StudentId = c.Int(),
                        YearId = c.Int(),
                        SubjectsId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .ForeignKey("dbo.Subjects", t => t.SubjectsId)
                .ForeignKey("dbo.Years", t => t.YearId)
                .Index(t => t.StudentId)
                .Index(t => t.YearId)
                .Index(t => t.SubjectsId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectsId = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(nullable: false, maxLength: 12),
                        PassMark = c.Int(nullable: false),
                        YearId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectsId);
            
            CreateTable(
                "dbo.Years",
                c => new
                    {
                        YearId = c.Int(nullable: false, identity: true),
                        YearNumber = c.Int(nullable: false),
                        YearName = c.String(),
                        Subjects_SubjectsId = c.Int(),
                    })
                .PrimaryKey(t => t.YearId)
                .ForeignKey("dbo.Subjects", t => t.Subjects_SubjectsId)
                .Index(t => t.Subjects_SubjectsId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 12),
                        LastName = c.String(nullable: false, maxLength: 12),
                        EmailAddress = c.String(nullable: false),
                        YearId = c.Int(nullable: false),
                        TitleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId)
                .ForeignKey("dbo.Titles", t => t.TitleId, cascadeDelete: true)
                .ForeignKey("dbo.Years", t => t.YearId, cascadeDelete: true)
                .Index(t => t.YearId)
                .Index(t => t.TitleId);
            
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        TitleId = c.Int(nullable: false, identity: true),
                        TitleName = c.String(),
                    })
                .PrimaryKey(t => t.TitleId);
            
            CreateTable(
                "dbo.Tribes",
                c => new
                    {
                        TribeId = c.Int(nullable: false, identity: true),
                        TribeName = c.String(),
                    })
                .PrimaryKey(t => t.TribeId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Students", "TribeId", "dbo.Tribes");
            DropForeignKey("dbo.Teachers", "YearId", "dbo.Years");
            DropForeignKey("dbo.Teachers", "TitleId", "dbo.Titles");
            DropForeignKey("dbo.Students", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Years", "Subjects_SubjectsId", "dbo.Subjects");
            DropForeignKey("dbo.StudentsSubjects", "YearId", "dbo.Years");
            DropForeignKey("dbo.Students", "YearId", "dbo.Years");
            DropForeignKey("dbo.StudentsSubjects", "SubjectsId", "dbo.Subjects");
            DropForeignKey("dbo.StudentsSubjects", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "ReligionId", "dbo.Religions");
            DropForeignKey("dbo.Students", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.Files", "Student_Id", "dbo.Students");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Teachers", new[] { "TitleId" });
            DropIndex("dbo.Teachers", new[] { "YearId" });
            DropIndex("dbo.Years", new[] { "Subjects_SubjectsId" });
            DropIndex("dbo.StudentsSubjects", new[] { "SubjectsId" });
            DropIndex("dbo.StudentsSubjects", new[] { "YearId" });
            DropIndex("dbo.StudentsSubjects", new[] { "StudentId" });
            DropIndex("dbo.Students", new[] { "TeacherId" });
            DropIndex("dbo.Students", new[] { "GenderId" });
            DropIndex("dbo.Students", new[] { "YearId" });
            DropIndex("dbo.Students", new[] { "TribeId" });
            DropIndex("dbo.Students", new[] { "ReligionId" });
            DropIndex("dbo.Files", new[] { "Student_Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Tribes");
            DropTable("dbo.Titles");
            DropTable("dbo.Teachers");
            DropTable("dbo.Years");
            DropTable("dbo.Subjects");
            DropTable("dbo.StudentsSubjects");
            DropTable("dbo.Religions");
            DropTable("dbo.Genders");
            DropTable("dbo.Students");
            DropTable("dbo.Files");
        }
    }
}
