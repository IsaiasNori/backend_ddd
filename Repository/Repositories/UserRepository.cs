
using Domain.Core.Models;
using Domain.Core.Repositories;
using Repository.Context;
using Repository.Entities;

namespace Repository.Repositories
{
    public class UserRepository : BaseRepository<UserModel, UserEntity>, IUserRepository
    {
        public UserRepository(CoreContext context) : base(context, context.UserEntity)
        {
        }
    }

}