using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GitApi.Models.Interface
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        Task<ActionResult<IEnumerable<TEntity>>> Create(TEntity instance);

        Task<ActionResult<IEnumerable<TEntity>>> Update(TEntity instance);

        //Task<ActionResult<IEnumerable<TEntity>>> Delete(TEntity instance);

        //TEntity Get(Expression<Func<TEntity, bool>> predicate);

        Task<ActionResult<IEnumerable<TEntity>>> GetAll();


    }
}
