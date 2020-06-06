namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Messages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        SendTime = c.DateTime(nullable: false),
                        OpenTime = c.DateTime(nullable: false),
                        SenderId = c.String(),
                        RecipientId = c.String(),
                        Users_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Users_Id)
                .Index(t => t.Users_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Message", "Users_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Message", new[] { "Users_Id" });
            DropTable("dbo.Message");
        }
    }
}
