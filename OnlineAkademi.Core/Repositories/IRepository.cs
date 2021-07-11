using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAkademi.Core.Repositories
{
    public interface IRepository<TEntity>:IDisposable where TEntity:class
    {
        #region Select Methods

        IEnumerable<TEntity> GetAll(bool isTracking = true);
        TEntity GetById(int id,bool isTracking=true);
        IEnumerable<TEntity> GetByFilter(Expression<Func<TEntity,bool>> filter,
            bool isTracking=true);
        TEntity GetSingle(Expression<Func<TEntity, bool>> filter, bool isTracking = true);

        #endregion

        #region Async Select Methods

        Task<IEnumerable<TEntity>> GetAllAsync(bool isTracking = true);
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> filter,
            bool isTracking = true);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter, bool isTracking = true);

        #endregion

        #region Update

        void Insert(TEntity entity);
        void Insert(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        #endregion
    }
}
