using System;
using Microsoft.EntityFrameworkCore;
using WebDotNetApplication.Data;
using WebDotNetApplication.DTO;
using WebDotNetApplication.Models;

namespace WebDotNetApplication.UserEndpoints;

public static class UserEndpoints
{
    const string EndpointName = "GetUser";

    // private static readonly List<UserDTO> usr = [
    //     new(1, "Alice", "alice@example.com", "Admin", 100.00M, new DateOnly(2023, 1, 1)),
    //     new(2, "Bob", "bob@example.com", "User", 200.00M, new DateOnly(2023, 2, 1)),
    //     new(3, "Charlie", "charlie@example.com", "User", 300.00M, new DateOnly(2023, 3, 1))
    // ];

    public static void MapUserEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/users");
        group.MapGet("/", async (WebAppContext dbcontext) =>
            await dbcontext.Users.Include(u => u.Role).Select(u =>
                new UserDTO(u.Id, u.Name, u.Email, u.Role!.NameRole, u.AccountBalance, u.CreatedDate)).ToListAsync()
            );


        group.MapGet("/{id}", async (int id, WebAppContext dbcontext) =>
        {
            var user = await dbcontext.Users.FindAsync(id);
            return user is null ? Results.NotFound() : Results.Ok(
                new UserInformationDTO(user.Id, user.Name, user.Email, user.RoleId, user.AccountBalance, user.CreatedDate)
            );
        }).WithName(EndpointName);


        group.MapPost("/", async (CreateUserDTO user, WebAppContext dbcontext) =>
        {
            // UserDTO newUser = new(
            //     usr.Count + 1,
            //     user.Name,
            //     user.Email,
            //     user.Role,
            //     user.AccountBalance,
            //     user.CreatedDate
            // );
            // usr.Add(newUser);
            User newusr = new()
            {
                Name = user.Name,
                Email = user.Email,
                RoleId = user.RoleId,
                AccountBalance = user.AccountBalance,
                CreatedDate = user.CreatedDate
            };
            dbcontext.Users.Add(newusr);
            await dbcontext.SaveChangesAsync();
            UserInformationDTO usrInfo = new(
                newusr.Id,
                newusr.Name,
                newusr.Email,
                newusr.RoleId,
                newusr.AccountBalance,
                newusr.CreatedDate
            );
            return Results.CreatedAtRoute(EndpointName, new { id = usrInfo.Id }, usrInfo);
        });


        group.MapPut("/{id}", async (int id, UpdateUserDTO user, WebAppContext dbcontext) =>
        {
            var existingUser = await dbcontext.Users.FindAsync(id);
            if (existingUser is null)
            {
                return Results.NotFound();
            }
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.RoleId = user.RoleId;
            existingUser.AccountBalance = user.AccountBalance;
            existingUser.CreatedDate = user.CreatedDate;
            await dbcontext.SaveChangesAsync();
            return Results.NoContent();
        });


        group.MapDelete("/{id}", async (int id, WebAppContext dbcontext) =>
        {
            await dbcontext.Users.Where(u => u.Id == id).ExecuteDeleteAsync();
            return Results.NoContent();
        });

    }
}
