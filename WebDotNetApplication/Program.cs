using WebDotNetApplication.DTO;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

List<UserDTO> usr = [
    new(1, "Alice", "alice@example.com",1, new DateOnly(2023, 1, 1)),
    new(2, "Bob", "bob@example.com",2.22M, new DateOnly(2023, 2, 1)),
    new(3, "Charlie", "charlie@example.com",3, new DateOnly(2023, 3, 1))
];

app.MapGet("/users", () => usr);

app.MapGet("/users/{id}", (int id) => {
    var user = usr.Find(u => u.Id == id);
    return user is null ? Results.NotFound() : Results.Ok(user);
}).WithName("GetUser");


app.MapPost("/users", (CreateUserDTO user) =>
{
    UserDTO newUser = new(
        usr.Count + 1,
        user.Name,
        user.Email,
        user.AccountBalance,
        user.CreatedDate
    );
    usr.Add(newUser);
    return Results.CreatedAtRoute("GetUser", new { id = newUser.Id }, newUser);
});


app.MapPut("/users/{id}", (int id, UpdateUserDTO user) =>
{
    var index = usr.FindIndex(u => u.Id == id);
    if(index == -1)
    {
        return Results.NotFound();
    }
    usr[index] = new UserDTO(id, user.Name, user.Email, user.AccountBalance, user.CreatedDate);
    return Results.NoContent();
});


app.MapDelete("/users/{id}", (int id) =>
{
    usr.RemoveAll(u => u.Id == id);
    return Results.NoContent();
});


app.Run();
