namespace KidKinder1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AboutLists",
                c => new
                    {
                        AboutListId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.AboutListId);
            
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        AboutId = c.Int(nullable: false, identity: true),
                        BigImageUrl = c.String(),
                        Header = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        SmallImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.AboutId);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        AddressDetail = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        OpeningHours = c.String(),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.BookASeats",
                c => new
                    {
                        BookASeatId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        ClassroomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookASeatId)
                .ForeignKey("dbo.Classrooms", t => t.ClassroomId, cascadeDelete: true)
                .Index(t => t.ClassroomId);
            
            CreateTable(
                "dbo.Classrooms",
                c => new
                    {
                        ClassroomId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        AgeofKids = c.String(),
                        TotalSeat = c.Byte(nullable: false),
                        ClassTime = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.ClassroomId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        Age = c.String(),
                        ClassroomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Classrooms", t => t.ClassroomId, cascadeDelete: true)
                .Index(t => t.ClassroomId);
            
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        ParentId = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        Phone = c.String(),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ParentId)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        BranchId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BranchId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        ImageUrl = c.String(),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Communications",
                c => new
                    {
                        CommunicationId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.CommunicationId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        Email = c.String(),
                        Subject = c.String(),
                        Message = c.String(),
                        SendDate = c.DateTime(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        FeatureId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Header = c.String(),
                        Description = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.FeatureId);
            
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        GalleryId = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GalleryId);
            
            CreateTable(
                "dbo.MailSubscribes",
                c => new
                    {
                        MailSubscribeId = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.MailSubscribeId);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ImageUrl = c.String(),
                        Description = c.String(),
                        NotificationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NotificationId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        IconUrl = c.String(),
                    })
                .PrimaryKey(t => t.ServiceId);
            
            CreateTable(
                "dbo.SocialMedias",
                c => new
                    {
                        SocialMediaId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.SocialMediaId);
            
            CreateTable(
                "dbo.Testimonials",
                c => new
                    {
                        TestimonialId = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        ImageUrl = c.String(),
                        Title = c.String(),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.TestimonialId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Parents", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "ClassroomId", "dbo.Classrooms");
            DropForeignKey("dbo.BookASeats", "ClassroomId", "dbo.Classrooms");
            DropIndex("dbo.Teachers", new[] { "BranchId" });
            DropIndex("dbo.Parents", new[] { "StudentId" });
            DropIndex("dbo.Students", new[] { "ClassroomId" });
            DropIndex("dbo.BookASeats", new[] { "ClassroomId" });
            DropTable("dbo.Testimonials");
            DropTable("dbo.SocialMedias");
            DropTable("dbo.Services");
            DropTable("dbo.Notifications");
            DropTable("dbo.MailSubscribes");
            DropTable("dbo.Galleries");
            DropTable("dbo.Features");
            DropTable("dbo.Contacts");
            DropTable("dbo.Communications");
            DropTable("dbo.Teachers");
            DropTable("dbo.Branches");
            DropTable("dbo.Parents");
            DropTable("dbo.Students");
            DropTable("dbo.Classrooms");
            DropTable("dbo.BookASeats");
            DropTable("dbo.Admins");
            DropTable("dbo.Addresses");
            DropTable("dbo.Abouts");
            DropTable("dbo.AboutLists");
        }
    }
}
