using DailyEntry.Core.Model;

namespace DailyEntry.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DailyEntry.Infrastructure.TrainningDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DailyEntry.Infrastructure.TrainningDB context)
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

            context.WorkoutTypes.AddOrUpdate(
                wt=> wt.Name,
                new WorkoutType {Name="Running", Description = string.Empty},
                new WorkoutType { Name = "Swimming", Description = string.Empty },
                new WorkoutType { Name = "Climbing", Description = string.Empty },
                new WorkoutType { Name = "Trekking", Description = string.Empty },
                new WorkoutType { Name = "Cycling", Description = string.Empty },
                new WorkoutType { Name = "Other", Description = string.Empty }
                );
        }
    }
}
