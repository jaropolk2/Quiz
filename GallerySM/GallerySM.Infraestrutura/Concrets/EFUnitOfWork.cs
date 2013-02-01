using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallerySM.Infraestrutura.Interfaces;

namespace GallerySM.Infraestrutura.Concrets
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private DbTransaction _transaction = null;
        
        public EFUnitOfWork(GallerySMContext contexto)
        {
            Contexto = contexto;            
        }

        public void Save()
        {
            Contexto.SaveChanges();            
        }

        public GallerySMContext Contexto
        {
            get;
            set;
        }

        public void Dispose()
        {
            if (Contexto != null)
                Contexto.Dispose();
        }      
        public void Commit()
        {
            if (_transaction != null)
            {
                Contexto.SaveChanges();
                _transaction.Commit();
            }
        }   
    }
}
