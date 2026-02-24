using System;
using Microsoft.EntityFrameworkCore;

namespace WebDotNetApplication.Data;

public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<WebAppContext>();
        context.Database.Migrate();
    }
}
