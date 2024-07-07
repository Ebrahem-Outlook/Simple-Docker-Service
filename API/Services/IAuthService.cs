using API.Contracts;
using API.Models;

namespace API.Services;

public interface IAuthService
{
    Task<bool> Register(RegisterRequest request, CancellationToken cancellationToken = default);

    Task<User?> Login(LoginRequest request, CancellationToken cancellationToken = default);
}
