namespace ExPho.Core.Migrations
{
    using Context;
    using Helpers;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
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
            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!rm.RoleExists(RolesHelper.ADMINISTRATOR))
                rm.Create(new IdentityRole(RolesHelper.ADMINISTRATOR));
            if (!rm.RoleExists(RolesHelper.TEACHER))
                rm.Create(new IdentityRole(RolesHelper.TEACHER));
            if (!rm.RoleExists(RolesHelper.LEARNER))
                rm.Create(new IdentityRole(RolesHelper.LEARNER));
            if (!rm.RoleExists(RolesHelper.JURY))
                rm.Create(new IdentityRole(RolesHelper.JURY));

            //if (!Roles.RoleExists(RolesHelper.ADMINISTRATOR))
            //    Roles.CreateRole(RolesHelper.ADMINISTRATOR);
            //if (!Roles.RoleExists(RolesHelper.TEACHER))
            //    Roles.CreateRole(RolesHelper.TEACHER);
            //if (!Roles.RoleExists(RolesHelper.LEARNER))
            //    Roles.CreateRole(RolesHelper.LEARNER);
            //if (!Roles.RoleExists(RolesHelper.JURY))
            //    Roles.CreateRole(RolesHelper.JURY);
        }
    }
}
