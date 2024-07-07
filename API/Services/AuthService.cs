using API.Contracts;
using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

internal sealed class AuthService(IDbContext dbContext, IUnitOfWork unitOfWork) : IAuthService
{
    public async Task<User?> Login(LoginRequest request, CancellationToken cancellationToken = default)
        => await dbContext.Set<User>()
        .FirstOrDefaultAsync(user => user.Email == request.Email.ToLower());


    public async Task<bool> Register(RegisterRequest request, CancellationToken cancellationToken = default)
    {
        bool IsUniqeEmail = await dbContext.Set<User>().AnyAsync(user => user.Email == request.Email.ToLower());

        if (IsUniqeEmail) return false;

        User user = User.Create(request.FirstName, request.LastName, request.Email, request.Password);

        await dbContext.Set<User>().AddAsync(user);

        await unitOfWork.SaveChangesAsync();

        return true;
    }
}
