using WebDotNetApplication.DTO;
using WebDotNetApplication.Data;
using WebDotNetApplication.UserEndpoints;
using WebDotNetApplication.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidation();
var conn = "Data Source=App.db";
builder.Services.AddSqlite<WebAppContext>(conn);
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<WebAppContext>();
    context.Database.EnsureCreated();

    if (!context.Set<Role>().Any())
    {
        context.Set<Role>().AddRange(
            new Role { NameRole = "Admin" },
            new Role { NameRole = "Sigma" },
            new Role { NameRole = "Chad" },
            new Role { NameRole = "Chillman" },
            new Role { NameRole = "Manager" },
            new Role { NameRole = "Supervisor" },
            new Role { NameRole = "Dominance" },
            new Role { NameRole = "Salvage" },
            new Role { NameRole = "King" },
            new Role { NameRole = "Queen" },
            new Role { NameRole = "Lord" },
            new Role { NameRole = "Daddy" },
            new Role { NameRole = "Overlord" },
            new Role { NameRole = "Shogun" },
            new Role { NameRole = "Pharaoh" },
            new Role { NameRole = "User" }
        );
        context.SaveChanges();
    }
}

app.MapGet("/", () => "Hello World!");


app.MapUserEndpoints();
app.MigrateDb(); // auto create database when not exist
app.Run();
