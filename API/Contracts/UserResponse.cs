using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace API.Contracts;

public sealed record UserResponse(
    Guid UserId, 
    string FirstName, 
    string LastName, 
    string Email,
    string Password);
