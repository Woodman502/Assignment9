namespace Homework9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PastDogs", "HotDogUser_Id", "dbo.HotDogUsers");
            DropIndex("dbo.PastDogs", new[] { "HotDogUser_Id" });
            AddColumn("dbo.HotDogUsers", "PastDog_Id", c => c.Int());
            CreateIndex("dbo.HotDogUsers", "PastDog_Id");
            AddForeignKey("dbo.HotDogUsers", "PastDog_Id", "dbo.PastDogs", "Id");
            DropColumn("dbo.PastDogs", "HotDogUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PastDogs", "HotDogUser_Id", c => c.Int());
            DropForeignKey("dbo.HotDogUsers", "PastDog_Id", "dbo.PastDogs");
            DropIndex("dbo.HotDogUsers", new[] { "PastDog_Id" });
            DropColumn("dbo.HotDogUsers", "PastDog_Id");
            CreateIndex("dbo.PastDogs", "HotDogUser_Id");
            AddForeignKey("dbo.PastDogs", "HotDogUser_Id", "dbo.HotDogUsers", "Id");
        }
    }
}
