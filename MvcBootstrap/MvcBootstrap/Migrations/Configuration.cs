namespace MvcBootstrap.Migrations
{
    using MvcBootstrap.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MvcBootstrap.Models.EmployeeContext";
        }

        protected override void Seed(EmployeeContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Employees.AddOrUpdate(
                x => x.Id,
            new Employee { Id = 1, Name = "Kevin", Mobile = "0912-422231", Email = "no@gmail.com", Department = "RD", Title = "�M��" },
            new Employee { Id = 2, Name = "Lissa", Mobile = "0912-422231", Email = "no@gmail.com", Department = "RD", Title = "�U�z" },
            new Employee { Id = 3, Name = "Sheldon", Mobile = "0912-422231", Email = "no@gmail.com", Department = "RD", Title = "����" },
            new Employee { Id = 4, Name = "Amy", Mobile = "0912-422231", Email = "no@gmail.com", Department = "RD", Title = "�ȪA" },
            new Employee { Id = 5, Name = "Penny", Mobile = "0912-422231", Email = "no@gmail.com", Department = "RD", Title = "�g��" }

                );


        }
    }
}
