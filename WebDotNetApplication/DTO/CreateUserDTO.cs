namespace WebDotNetApplication.DTO;

public record CreateUserDTO(
    string Name,
    string Email,
    decimal AccountBalance,
    DateOnly CreatedDate
);

