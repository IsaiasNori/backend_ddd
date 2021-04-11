

using System;
using System.Linq;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace Repository.Repositories
{
    public class UserRepository : BaseRepository<UserModel, User>, IUserRepository
    {
        public UserRepository(CoreContext context) : base(context, context.User)
        {
        }

        public UserModel Get(String name, String password)
        {
            try
            {
                var result = _db
                    .Where(e =>
                        e.Name == name &&
                        e.Password == password &&
                        e.DeletedAt == null)
                    .AsNoTracking()
                    .FirstOrDefault()
                    .ToModel();

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected override User RemoveRelations(User entity)
        {
            return entity;
        }
    }

}