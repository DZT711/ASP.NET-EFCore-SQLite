using WebDotNetApplication.DTO;
using WebDotNetApplication.Data;
using WebDotNetApplication.UserEndpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidation();
var conn = "Data Source=App.db";
builder.Services.AddSqlite<WebAppContext>(conn);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");


app.MapUserEndpoints();
app.MigrateDb(); // auto create database when not exist
app.Run();
