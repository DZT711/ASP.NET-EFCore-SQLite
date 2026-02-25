using WebDotNetApplication.DTO;
using WebDotNetApplication.Data;
using WebDotNetApplication.UserEndpoints;
using WebDotNetApplication.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidation();
builder.AddDataToDatabase();
var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.MapUserEndpoints();
app.MigrateDb(); // auto create database when not exist
app.Run();
