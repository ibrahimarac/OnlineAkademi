
using OnlineAkademi.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAkademi.Data.Sql.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity:class
    {
        protected readonly IlknurContext Context;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(IlknurContext context)
        {
            Context = context ?? throw new ArgumentNullException($"{nameof(context)} DependencyInjection'a servis olarak kaydedilmemiş.");
            DbSet = Context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll(bool isTracking = true)
        {
            return isTracking ? DbSet : DbSet.AsNoTracking();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool isTracking = true)
        {
            return isTracking ? await DbSet.ToListAsync() : await DbSet.AsNoTracking().ToListAsync();
        }

        public IEnumerable<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter, bool isTracking = true)
        {
            return isTracking ? DbSet.Where(filter) : DbSet.AsNoTracking().Where(filter);
        }

        public async Task<IEnumerable<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> filter, bool isTracking = true)
        {
            return isTracking ? await DbSet.Where(filter).ToListAsync() : await DbSet.AsNoTracking().Where(filter).ToListAsync();
        }

        public TEntity GetById(int id,bool isTracking=true)
        {
            var entity = DbSet.Find(id);
            if (!isTracking && entity != null)
                Context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public TEntity GetSingle(Expression<Func<TEntity, bool>> filter, bool isTracking = true)
        {
            return isTracking ? DbSet.SingleOrDefault(filter) : DbSet.AsNoTracking().SingleOrDefault(filter);
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter, bool isTracking = true)
        {
            return isTracking ? await DbSet.SingleOrDefaultAsync(filter) : await DbSet.AsNoTracking().SingleOrDefaultAsync(filter);
        }


        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }


        public void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            DbSet.AddRange(entities);
        }


        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }



        bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
                //unmanaged codes disposed here
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

       
    }
}
