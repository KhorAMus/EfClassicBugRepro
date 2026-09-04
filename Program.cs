using EfClassicBugRepro.Data;
using EfClassicBugRepro.Migrations;
using System.Data.Entity;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDbContext, Configuration>());

using (var scope = app.Services.CreateScope())
using (var context = new AppDbContext())
{
    context.Database.Initialize(false);
}

app.MapGet("/", () => Results.Ok(new
{
    Message = "EF Classic bug reproduction project is running.",
    Table = "BugRecords"
}));

app.Run();
