//####################################################################
// Project:         Tech & Solve
// Author:          Jonathan Dávila A.
// DATA:            01/10/2019
// Comment:         interfaz encargada de exponer el positorio de data
//####################################################################
namespace Solve.DM.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;

    public interface IBaseRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllBy(Expression<Func<TEntity, bool>> predicate);
        TEntity FindById(object id);
        void Create(TEntity entity);
        void Delete(TEntity entity);
    }
}
