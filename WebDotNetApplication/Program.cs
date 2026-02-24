using WebDotNetApplication.DTO;
using WebDotNetApplication.UserEndpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");


app.MapUserEndpoints();

app.Run();
