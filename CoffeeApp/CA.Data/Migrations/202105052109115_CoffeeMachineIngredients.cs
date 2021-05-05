namespace CA.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CoffeeMachineIngredients : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CoffeeMachineIngredients", "MaxVolume", c => c.Single(nullable: false));
            DropColumn("dbo.CoffeeMachineIngredients", "IsDefault");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CoffeeMachineIngredients", "IsDefault", c => c.Boolean(nullable: false));
            DropColumn("dbo.CoffeeMachineIngredients", "MaxVolume");
        }
    }
}
