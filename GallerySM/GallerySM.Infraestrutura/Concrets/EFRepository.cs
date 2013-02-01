using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallerySM.Infraestrutura.Interfaces;

namespace GallerySM.Infraestrutura.Concrets
{
    public class EFRepository<T> : IDisposable, IRepository<T> where T : class
    {
        public IUnitOfWork UnitOfWork { get; set; }
        private DbSet<T> _dbSet = null;
        private DbSet<T> DbSet
        {
            get
            {
                if (_dbSet == null)
                {
                    _dbSet = UnitOfWork.Contexto.Set<T>();
                }
                return _dbSet;
            }
        }


        public EFRepository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public virtual IQueryable<T> All()
        {
            return DbSet.AsQueryable();
        }

        public IQueryable<T> Find(Func<T, bool> expression)
        {
            return DbSet.Where(expression).AsQueryable();
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public void Save()
        {
            UnitOfWork.Save();
        }

        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}