using System.ComponentModel.DataAnnotations;

namespace WebDotNetApplication.DTO;

public record CreateUserDTO(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(50)] string Email,
    [Required][Range(0, 1000000000)] decimal AccountBalance,
    DateOnly CreatedDate
);

