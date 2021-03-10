namespace CA.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CA.Data.EFDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CA.Data.EFDBContext";
        }

        protected override void Seed(CA.Data.EFDBContext context)
        {
            StartData.InitData(context);
        }
    }
}
