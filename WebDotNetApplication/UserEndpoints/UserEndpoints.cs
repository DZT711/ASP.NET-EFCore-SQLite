using System;
using WebDotNetApplication.DTO;

namespace WebDotNetApplication.UserEndpoints;

public static class UserEndpoints
{
    const string EndpointName = "GetUser";

    private static readonly List<UserDTO> usr = [
        new(1, "Alice", "alice@example.com", "Admin", 100.00M, new DateOnly(2023, 1, 1)),
    new(2, "Bob", "bob@example.com", "User", 200.00M, new DateOnly(2023, 2, 1)),
    new(3, "Charlie", "charlie@example.com", "User", 300.00M, new DateOnly(2023, 3, 1))
    ];

    public static void MapUserEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/users");
        group.MapGet("/", () => usr);


        group.MapGet("/{id}", (int id) =>
        {
            var user = usr.Find(u => u.Id == id);
            return user is null ? Results.NotFound() : Results.Ok(user);
        }).WithName(EndpointName);


        group.MapPost("/", (CreateUserDTO user) =>
        {
            UserDTO newUser = new(
                usr.Count + 1,
                user.Name,
                user.Email,
                user.Role,
                user.AccountBalance,
                user.CreatedDate
            );
            usr.Add(newUser);
            return Results.CreatedAtRoute(EndpointName, new { id = newUser.Id }, newUser);
        });


        group.MapPut("/{id}", (int id, UpdateUserDTO user) =>
        {
            var index = usr.FindIndex(u => u.Id == id);
            if (index == -1)
            {
                return Results.NotFound();
            }
            usr[index] = new UserDTO(id, user.Name, user.Email, user.Role, user.AccountBalance, user.CreatedDate);
            return Results.NoContent();
        });


        group.MapDelete("/{id}", (int id) =>
        {
            usr.RemoveAll(u => u.Id == id);
            return Results.NoContent();
        });

    }
}
