namespace WebDotNetApplication.DTO;

public record UpdateUserDTO(
    string Name,
    string Email,
    decimal AccountBalance,
    DateOnly CreatedDate
);