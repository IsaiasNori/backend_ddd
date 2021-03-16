using Domain.Core.Models;
using Domain.Core.Repositories;

namespace Domain.Core.Services
{
    public abstract class IUserService : BaseService<UserModel>
    {
        public IUserService(IUserRepository repository) : base(repository)
        {
                
        }
    }

}