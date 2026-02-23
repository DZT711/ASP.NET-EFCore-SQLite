namespace WebDotNetApplication.DTO;

public record UserDTO
(
    int Id,
    string Name,
    string Email,
    decimal AccountBalance,
    DateOnly CreatedDate
);