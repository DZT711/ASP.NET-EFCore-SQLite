using System;
using Microsoft.EntityFrameworkCore; //import EF Core
using WebDotNetApplication.Models;

namespace WebDotNetApplication.Data;

public class WebAppContext(DbContextOptions<WebAppContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();    
}
