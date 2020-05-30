namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAdvertisement : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Advertisement", new[] { "Categories_Id" });
            RenameColumn(table: "dbo.Advertisement", name: "Categories_Id", newName: "CategoriesId");
            AlterColumn("dbo.Advertisement", "CategoriesId", c => c.Int(nullable: false));
            CreateIndex("dbo.Advertisement", "CategoriesId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Advertisement", new[] { "CategoriesId" });
            AlterColumn("dbo.Advertisement", "CategoriesId", c => c.Int());
            RenameColumn(table: "dbo.Advertisement", name: "CategoriesId", newName: "Categories_Id");
            CreateIndex("dbo.Advertisement", "Categories_Id");
        }
    }
}
