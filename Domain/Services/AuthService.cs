using Domain.Core.Services;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Domain.Services
{
    public class AuthService : BaseService<UserModel, IUserRepository>, IAuthService
    {
        public AuthService(IUserRepository repository) : base(repository)
        {
        }
    }
}