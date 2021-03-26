namespace EasyNote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuthorRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notes", "AuthorId", "dbo.AspNetUsers");
            DropIndex("dbo.Notes", new[] { "AuthorId" });
            AlterColumn("dbo.Notes", "AuthorId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Notes", "AuthorId");
            AddForeignKey("dbo.Notes", "AuthorId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "AuthorId", "dbo.AspNetUsers");
            DropIndex("dbo.Notes", new[] { "AuthorId" });
            AlterColumn("dbo.Notes", "AuthorId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Notes", "AuthorId");
            AddForeignKey("dbo.Notes", "AuthorId", "dbo.AspNetUsers", "Id");
        }
    }
}
