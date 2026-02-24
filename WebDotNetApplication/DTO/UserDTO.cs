namespace WebDotNetApplication.DTO;

public record UserDTO
(
    int Id,
    string Name,
    string Email,
    string Role,
    decimal AccountBalance,
    DateOnly CreatedDate
);