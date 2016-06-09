namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inheritance : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Instructor", newName: "Person");
            AddColumn("dbo.Person", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Person", "EmailAddress", c => c.String());
            AddColumn("dbo.Person", "EnrollmentDate", c => c.DateTime());
            AddColumn("dbo.Person", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Person", "HireDate", c => c.DateTime());
            DropColumn("dbo.Person", "First Name");
            DropTable("dbo.Student");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(name: "First Name", nullable: false, maxLength: 50),
                        EmailAddress = c.String(),
                        EnrollmentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Person", "First Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Person", "HireDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Person", "Discriminator");
            DropColumn("dbo.Person", "EnrollmentDate");
            DropColumn("dbo.Person", "EmailAddress");
            DropColumn("dbo.Person", "FirstName");
            RenameTable(name: "dbo.Person", newName: "Instructor");
        }
    }
}
