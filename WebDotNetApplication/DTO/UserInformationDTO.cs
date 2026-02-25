namespace WebDotNetApplication.DTO;

public record UserInformationDTO
(
    int Id,
    string Name,
    string Email,
    int RoleId,
    decimal AccountBalance,
    DateOnly CreatedDate
);