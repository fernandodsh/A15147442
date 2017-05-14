using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace A15147442_ENT.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //C
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        //R
        TEntity Get(int Id);
        IEnumerable<TEntity> GetAll();
        IEnumerator<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        //U
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        //D
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
    }
}
