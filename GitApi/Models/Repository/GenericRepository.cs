using GitApi.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GitApi.Models.Repository
{
    public class GenericRepository<TEntity> : ControllerBase, IRepository<TEntity>
        where TEntity : class
    {
        private DbContext _context
        {
            get;
        }

        public GenericRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            _context = context;
        }

        /// <summary>
        /// Creates the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <exception cref="System.ArgumentNullException">instance</exception>
        public async Task<ActionResult<IEnumerable<TEntity>>> Create(TEntity instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                _context.Set<TEntity>().Add(instance);
                await _context.SaveChangesAsync();
            }
            return NoContent();
        }

        /// <summary>
        /// Updates the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<ActionResult<IEnumerable<TEntity>>> Update(TEntity instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                _context.Entry(instance).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return NoContent();
        }

        /// <summary>
        /// Deletes the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        //public async Task<ActionResult<IEnumerable<TEntity>>> Delete(TEntity instance)
        //{
        //    if (instance == null)
        //    {
        //        throw new ArgumentNullException("instance");
        //    }
        //    else
        //    {
        //        this._context.Entry(instance).State = EntityState.Deleted;
        //        await this.SaveChangesAsync();
        //    }
        //}

        /// <summary>
        /// Gets the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        //public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return _context.Set<TEntity>().FirstOrDefault(predicate);
        //}

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<IEnumerable<TEntity>>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }



        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._context != null)
                {
                    this._context.Dispose();
                    //this._context = null;
                }
            }
        }

    }
}
