using EfClassicBugRepro.Data;
using System.Data.Entity.Migrations;

namespace EfClassicBugRepro.Migrations;

public class Configuration : DbMigrationsConfiguration<AppDbContext>
{
    public Configuration()
    {
        AutomaticMigrationsEnabled = true;
        AutomaticMigrationDataLossAllowed = true;
    }

    protected override void Seed(AppDbContext context)
    {
        if (!context.BugRecords.Any())
        {
            context.BugRecords.Add(new Models.BugRecord
            {
                Value = "Initial record"
            });

            context.SaveChanges();
        }
    }
}
