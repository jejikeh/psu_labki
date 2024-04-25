using ProjectManager.Domain;

namespace ProjectManager.Application.Services;

public interface IUserRepository : IRepository<User>
{
    public Task<bool> CheckPasswordAsync(User user, string password);
    public Task<User> CreateAsync(User attachment, string password, string role = "User");
    public Task SetRoleAsync(User user, Role role);
    
    public new Task<User> CreateAsync(User user)
    {
        throw new InvalidOperationException("UserRepository.CreateAsync require password!");
    }
}
