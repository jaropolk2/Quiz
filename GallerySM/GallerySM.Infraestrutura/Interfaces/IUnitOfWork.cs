using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using GallerySM.Infraestrutura.Concrets;

namespace GallerySM.Infraestrutura.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        GallerySMContext Contexto { get; set; }
        //DbTransaction BeginTransaction(IsolationLevel level);
        //void Commit();
        //void RollBack();
    }
}
