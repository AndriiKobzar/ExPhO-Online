namespace ExPho.Core.Migrations
{
    using Heplers;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;

    internal sealed class Configuration : DbMigrationsConfiguration<ExPho.Core.Context.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ExPho.Core.Context.ApplicationDbContext context)
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
            if (Roles.RoleExists(RolesHelper.ADMINISTRATOR))
                Roles.CreateRole(RolesHelper.ADMINISTRATOR);
            if (Roles.RoleExists(RolesHelper.TEACHER))
                Roles.CreateRole(RolesHelper.TEACHER);
            if (Roles.RoleExists(RolesHelper.LEARNER))
                Roles.CreateRole(RolesHelper.LEARNER);
            if (Roles.RoleExists(RolesHelper.JURY))
                Roles.CreateRole(RolesHelper.JURY);
        }
    }
}
