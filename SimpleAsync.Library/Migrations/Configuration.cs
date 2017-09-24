namespace SimpleAsync.Library.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SimpleAsync.Library.SimpleDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SimpleAsync.Library.SimpleDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.FunFacts.AddOrUpdate(
                f => f.Id,
                new FunFact { Fact = "Save lots of equipment from the landfill." },
                new FunFact { Fact="Ship medical equipment and supplies worldwide."},
                new FunFact {  Fact="Based in Nampa, Idaho"}
            
            );

        }
    }
}
