//####################################################################
// Project:         Tech & Solve
// Author:          Jonathan Dávila A.
// DATA:            01/10/2019
// Comment:         Clase encargada de administrar el positorio de data
//####################################################################
namespace Solve.DM.Repository
{
    using Microsoft.EntityFrameworkCore;
    using Solve.DM.Database;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected Solve_AuditoriaContext Db = new Solve_AuditoriaContext();
        protected DbSet<TEntity> Data;

        //Constructor
        public BaseRepository(Solve_AuditoriaContext _Db)
        {
            Db = _Db;
            Data = Db.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            Data.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            Data.Remove(entity);
            Db.SaveChanges();
        }

        public TEntity FindById(object id)
        {
            return Data.Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Data;
        }

        public IQueryable<TEntity> GetAllBy(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = Data.Where(predicate);
            return query;
        }

    }
}
