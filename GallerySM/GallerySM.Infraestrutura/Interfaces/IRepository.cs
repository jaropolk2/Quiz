using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GallerySM.Infraestrutura.Interfaces
{
    public interface IRepository<T>
    {
        IUnitOfWork UnitOfWork { get; set; }
        IQueryable<T> All();
        IQueryable<T> Find(Func<T, bool> expression);
        void Add(T entity);
        void Delete(T entity);
        void Save();
    }
}
