namespace NaptaWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ahmed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PostID = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ApplicationUser", t => t.User_Id)
                .ForeignKey("dbo.Post", t => t.PostID, cascadeDelete: true)
                .Index(t => t.PostID)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Image = c.String(),
                        PlantID = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ApplicationUser", t => t.User_Id)
                .ForeignKey("dbo.Plant", t => t.PlantID, cascadeDelete: true)
                .Index(t => t.PlantID)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(nullable: false, maxLength: 256),
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
                "dbo.Plant",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Disease",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Description = c.String(nullable: false),
                        Treatment = c.String(),
                        Plant_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.Plant", t => t.Plant_ID)
                .Index(t => t.Plant_ID);
            
            CreateTable(
                "dbo.PlantDiseases",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Treatment = c.String(nullable: false),
                        PlantID = c.Int(nullable: false),
                        DiseaseName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Disease", t => t.DiseaseName)
                .ForeignKey("dbo.Plant", t => t.PlantID, cascadeDelete: true)
                .Index(t => t.PlantID)
                .Index(t => t.DiseaseName);
            
            CreateTable(
                "dbo.TestDisease",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TestID = c.Int(nullable: false),
                        DiseaseName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Disease", t => t.DiseaseName)
                .ForeignKey("dbo.Test", t => t.TestID, cascadeDelete: true)
                .Index(t => t.TestID)
                .Index(t => t.DiseaseName);
            
            CreateTable(
                "dbo.Test",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false, storeType: "date"),
                        Image = c.String(nullable: false),
                        PlantID = c.Int(nullable: false),
                        IsHealthy = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Plant", t => t.PlantID, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUser", t => t.User_Id)
                .Index(t => t.PlantID)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Plan",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PlantID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Plant", t => t.PlantID, cascadeDelete: true)
                .Index(t => t.PlantID);
            
            CreateTable(
                "dbo.PlanFertilizers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlanID = c.Int(nullable: false),
                        WeekNum = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                        FertilizerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fertilizer", t => t.FertilizerID, cascadeDelete: true)
                .ForeignKey("dbo.Plan", t => t.PlanID, cascadeDelete: true)
                .Index(t => t.PlanID)
                .Index(t => t.FertilizerID);
            
            CreateTable(
                "dbo.Fertilizer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
            
            CreateTable(
                "dbo.Nationalities",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Name);
            
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.PlantApplicationUsers",
                c => new
                    {
                        Plant_ID = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Plant_ID, t.ApplicationUser_Id })
                .ForeignKey("dbo.Plant", t => t.Plant_ID, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Plant_ID)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUserPosts",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Post_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Post_ID })
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Post", t => t.Post_ID, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Post_ID);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Nationality_Name = c.String(maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        ProfilePic = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.Nationalities", t => t.Nationality_Name)
                .Index(t => t.Id)
                .Index(t => t.Nationality_Name);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUser", "Nationality_Name", "dbo.Nationalities");
            DropForeignKey("dbo.ApplicationUser", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Comment", "PostID", "dbo.Post");
            DropForeignKey("dbo.Post", "PlantID", "dbo.Plant");
            DropForeignKey("dbo.ApplicationUserPosts", "Post_ID", "dbo.Post");
            DropForeignKey("dbo.ApplicationUserPosts", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Plan", "PlantID", "dbo.Plant");
            DropForeignKey("dbo.PlanFertilizers", "PlanID", "dbo.Plan");
            DropForeignKey("dbo.PlanFertilizers", "FertilizerID", "dbo.Fertilizer");
            DropForeignKey("dbo.PlantApplicationUsers", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.PlantApplicationUsers", "Plant_ID", "dbo.Plant");
            DropForeignKey("dbo.Disease", "Plant_ID", "dbo.Plant");
            DropForeignKey("dbo.Test", "User_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.TestDisease", "TestID", "dbo.Test");
            DropForeignKey("dbo.Test", "PlantID", "dbo.Plant");
            DropForeignKey("dbo.TestDisease", "DiseaseName", "dbo.Disease");
            DropForeignKey("dbo.PlantDiseases", "PlantID", "dbo.Plant");
            DropForeignKey("dbo.PlantDiseases", "DiseaseName", "dbo.Disease");
            DropForeignKey("dbo.Post", "User_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Comment", "User_Id", "dbo.ApplicationUser");
            DropIndex("dbo.ApplicationUser", new[] { "Nationality_Name" });
            DropIndex("dbo.ApplicationUser", new[] { "Id" });
            DropIndex("dbo.ApplicationUserPosts", new[] { "Post_ID" });
            DropIndex("dbo.ApplicationUserPosts", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.PlantApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.PlantApplicationUsers", new[] { "Plant_ID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.PlanFertilizers", new[] { "FertilizerID" });
            DropIndex("dbo.PlanFertilizers", new[] { "PlanID" });
            DropIndex("dbo.Plan", new[] { "PlantID" });
            DropIndex("dbo.Test", new[] { "User_Id" });
            DropIndex("dbo.Test", new[] { "PlantID" });
            DropIndex("dbo.TestDisease", new[] { "DiseaseName" });
            DropIndex("dbo.TestDisease", new[] { "TestID" });
            DropIndex("dbo.PlantDiseases", new[] { "DiseaseName" });
            DropIndex("dbo.PlantDiseases", new[] { "PlantID" });
            DropIndex("dbo.Disease", new[] { "Plant_ID" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Post", new[] { "User_Id" });
            DropIndex("dbo.Post", new[] { "PlantID" });
            DropIndex("dbo.Comment", new[] { "User_Id" });
            DropIndex("dbo.Comment", new[] { "PostID" });
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.ApplicationUserPosts");
            DropTable("dbo.PlantApplicationUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Nationalities");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Fertilizer");
            DropTable("dbo.PlanFertilizers");
            DropTable("dbo.Plan");
            DropTable("dbo.Test");
            DropTable("dbo.TestDisease");
            DropTable("dbo.PlantDiseases");
            DropTable("dbo.Disease");
            DropTable("dbo.Plant");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Post");
            DropTable("dbo.Comment");
        }
    }
}
