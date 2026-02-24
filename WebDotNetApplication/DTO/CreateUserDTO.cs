using System.ComponentModel.DataAnnotations;

namespace WebDotNetApplication.DTO;

public record CreateUserDTO(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(50)] string Email,
    [Required][StringLength(50)] string Role,
    [Required][Range(0, 1000000000)] decimal AccountBalance,
    DateOnly CreatedDate
);

