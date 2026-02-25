using System;
using Microsoft.EntityFrameworkCore;
using WebDotNetApplication.Models;

namespace WebDotNetApplication.Data;

public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<WebAppContext>();
        context.Database.Migrate();
    }
    public static void AddDataToDatabase(this WebApplicationBuilder builder)
    {
        var conn = "Data Source=App.db";
        builder.Services.AddSqlite<WebAppContext>(
                        conn,
                        optionsAction: options => options.UseSeeding((context, _) =>
                        {
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
                    )
                );
    }
}
