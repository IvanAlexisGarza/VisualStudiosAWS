namespace Softtek.Academy2018.ToDoListApp.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Softtek.Academy2018.ToDoListApp.Data.ToDoListContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Softtek.Academy2018.ToDoListApp.Data.ToDoListContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Status.Add(new Domain.Model.Status { Id = 1, Description = "Draft", CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Status.Add(new Domain.Model.Status { Id = 2, Description = "Ready", CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Status.Add(new Domain.Model.Status { Id = 3, Description = "In Progress", CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Status.Add(new Domain.Model.Status { Id = 4, Description = "Done", CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Status.Add(new Domain.Model.Status { Id = 5, Description = "Cancelled", CreatedDate = DateTime.Now, ModifiedDate = null });
        }
    }
}
