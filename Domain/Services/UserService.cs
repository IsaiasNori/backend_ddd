
using Domain.Core.Repositories;

namespace Domain.Core.Services
{
    public class UserService : IUserService
    {
        public UserService(IUserRepository repository) : base(repository)
        {
                
        }
    }

}