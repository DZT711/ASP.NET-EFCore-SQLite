using System;
using Microsoft.EntityFrameworkCore;
using WebDotNetApplication.Data;
using WebDotNetApplication.DTO;

namespace WebDotNetApplication.UserEndpoints;

public static class RoleEndpoints 
{
    public static void MapRolesEndpoints (this WebApplication app)
    {
        var gr= app.MapGroup("/roles");
        gr.MapGet("/", async (WebAppContext context) => await context.Roles.Select(r => new RoleDTO(r.Id, r.NameRole)).AsNoTracking().ToListAsync());
    }
}
