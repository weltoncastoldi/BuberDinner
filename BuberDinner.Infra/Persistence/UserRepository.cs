using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infra.Persistence;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users = new();
    public User? GetUserByEmaiL(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }

    public void Add(User user)
    {
        _users.Add(user);
    }
}