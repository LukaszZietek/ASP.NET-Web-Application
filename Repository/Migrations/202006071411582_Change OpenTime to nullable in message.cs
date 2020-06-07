namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeOpenTimetonullableinmessage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Message", "OpenTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Message", "OpenTime", c => c.DateTime(nullable: false));
        }
    }
}
