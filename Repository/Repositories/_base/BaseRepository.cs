using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Core.Models;
using Domain.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Entities;

namespace Repository.Repositories
{
    public abstract class BaseRepository<M, E> : IRepository<M> where M : BaseModel where E : BaseEntity
    {
        protected CoreContext _context;
        protected DbSet<E> _db;

        public BaseRepository(CoreContext context, DbSet<E> db)
        {
            _context = context;
            _db = db;

        }

        public List<M> Get()
        {
            try
            {
                var result = _db
                    .Where(e => e.DeletedAt == null)
                    .AsNoTracking()
                    .Select(e => (M)e)
                    .ToList();

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public M Get(String id)
        {
            try
            {
                var result = _db
                    .Where(e =>
                        e.Id == id &&
                        e.DeletedAt == null)
                    .AsNoTracking()
                    .Select(e => (M)e)
                    .FirstOrDefault();

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public M Insert(M model, Boolean commit = false)
        {
            try
            {
                var entity = (E)model;

                _db.Add(entity);

                var result = (M)entity;

                if (commit)
                    _context.SaveChanges();

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public M Update(M model, Boolean commit = false)
        {
            try
            {
                var entity = (E)model;

                _db.Add(entity);

                var result = (M)entity;

                if (commit)
                    _context.SaveChanges();

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public M SoftDelete(M model, Boolean commit = false)
        {
            try
            {
                var entity = (E)model;

                entity.SetSoftDelete();

                var result = Update((M)entity, commit);

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void CommitChanges()
        {
            _context.SaveChanges();
        }
    }
}
