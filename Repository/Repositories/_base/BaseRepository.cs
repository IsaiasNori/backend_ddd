using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Models;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Domain.Utils;

namespace Repository.Repositories
{
    public abstract class BaseRepository<M, E> : IRepository<M>
        where M : BaseModel
        where E : BaseEntity<M>
    {
        protected CoreContext _context;
        protected DbSet<E> _db;

        private BaseRepository() { }

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
                    .Where(e =>
                        e.DeletedAt == null)
                    .AsNoTracking()
                    .Select(e => e.ToModel())
                    .ToList();

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public PagedList<M> Get(Int32 page, Int32 size)
        {
            try
            {
                var skip = (page > 0) ? page * size : 0;
                var take = size;

                var models = _db
                    .Where(e =>
                        e.DeletedAt == null)
                    .Skip(skip)
                    .Take(take)
                    .AsNoTracking()
                    .Select(e => e.ToModel())
                    .ToList();

                PagedList<M> result = new PagedList<M>(models, skip, take);

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
                    .FirstOrDefault()
                    .ToModel();

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public String Insert(M model, Boolean commit = false)
        {
            try
            {
                if (EntityExists(model.Id)) throw new Exception("ALREADY_EXIST");

                E entity = InstantiateEntity(model);

                _db.Add(entity);

                if (commit)
                    _context.SaveChanges();

                var result = entity.Id;

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<String> Insert(List<M> models, Boolean commit = false)
        {
            try
            {
                models.ForEach(m =>
                {
                    if (EntityExists(m.Id)) throw new Exception("ALREADY_EXIST");
                });

                List<E> entities = models
                    .Select(m => InstantiateEntity(m)).ToList();

                _db.AddRange(entities);

                if (commit)
                    _context.SaveChanges();

                var result = models.Select(m => m.Id).ToList();

                return result;
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public void Update(M model, Boolean commit = false)
        {
            try
            {
                if (!EntityExists(model.Id)) throw new Exception("NOT_FOUND");

                E entity = InstantiateEntity(model);

                _db.Update(entity);

                if (commit)
                    _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(List<M> models, Boolean commit = false)
        {
            try
            {
                models.ForEach(m =>
                {
                    if (!EntityExists(m.Id)) throw new Exception("NOT_FOUND");
                });

                List<E> entities = models
                    .Select(m => InstantiateEntity(m)).ToList();

                _db.UpdateRange(entities);

                if (commit)
                    _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected virtual E InstantiateEntity(M model)
        {
            E entity = Activator.CreateInstance<E>();

            entity.FromModel(model);

            return RemoveRelations(entity);
        }

        protected virtual Boolean EntityExists(String id) => _db.Any(e => e.Id == id);


        protected abstract E RemoveRelations(E entity);

    }
}
