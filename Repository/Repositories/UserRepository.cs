

using Domain.Interfaces.Repositories;
using Domain.Models;
using Repository.Context;
using Repository.Entities;

namespace Repository.Repositories
{
    public class UserRepository : BaseRepository<UserModel, UserEntity>, IUserRepository
    {
        public UserRepository(CoreContext context) : base(context, context.UserEntity)
        {
        }

        protected override UserEntity RemoveRelations(UserEntity entity)
        {
            return entity;
        }
    }

}