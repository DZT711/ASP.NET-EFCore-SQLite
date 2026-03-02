using WebDotNetApplication.DTO;
using WebDotNetApplication.Data;
using WebDotNetApplication.UserEndpoints;
using WebDotNetApplication.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidation();
builder.AddDataToDatabase();
// 1. Đăng ký dịch vụ CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor",
        policy => policy.WithOrigins("http://localhost:5139") // Đúng Port của FE bạn gửi
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

builder.Services.AddControllers();

var app = builder.Build();

// 2. Kích hoạt CORS (Phải đặt TRƯỚC MapControllers)
app.UseCors("AllowBlazor");

// app.UseHttpsRedirection();
app.MapControllers();
app.MapGet("/", () => "Hello World!");
app.MapUserEndpoints();
app.MapRolesEndpoints();
app.MigrateDb(); // auto create database when not exist
app.Run();
