using ProjectManager.Application.Common.Models;
using ProjectManager.Domain;

namespace ProjectManager.Application.Services;

public interface IAuthorizationTokenService
{
    public Task<AuthorizationToken> CreateAsync(User user);
}