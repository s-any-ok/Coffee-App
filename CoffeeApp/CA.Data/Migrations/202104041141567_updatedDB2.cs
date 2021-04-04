namespace CA.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedDB2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "CoffeeMachineId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "CoffeeMachineId");
            AddForeignKey("dbo.Orders", "CoffeeMachineId", "dbo.CoffeeMachines", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CoffeeMachineId", "dbo.CoffeeMachines");
            DropIndex("dbo.Orders", new[] { "CoffeeMachineId" });
            DropColumn("dbo.Orders", "CoffeeMachineId");
        }
    }
}
