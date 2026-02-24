using System;

namespace WebDotNetApplication.Models;

public class User
{
 public int Id { get; set; }
 public required string Name { get; set; }
 public required string Email { get; set; }
 public Role? Role { get; set; }
 public int RoleId { get; set; } // foreign key
 public decimal AccountBalance { get; set; }
 public DateOnly CreatedDate { get; set; }
}
