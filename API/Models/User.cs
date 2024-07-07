namespace API.Models;

public sealed class User
{
    private User(Guid id, string firstName, string lastName, string email, string password)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    private User() { }

    public Guid Id { get; }
    public string FirstName { get; } = default!;
    public string LastName { get; } = default!;
    public string Email { get; } = default!;
    public string Password { get; } = default!;

    public static User Create(string firstName, string lastName, string email, string password)
    {
        User user = new User(Guid.NewGuid(), firstName, lastName, email, password);

        return user;
    }
}
