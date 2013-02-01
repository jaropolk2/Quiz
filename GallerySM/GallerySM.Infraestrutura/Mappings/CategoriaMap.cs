using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallerySM.Domain.Domains;
using GallerySM.Domain.Domains.Games.Quiz;
using GallerySM.Domain.Games.Quiz;

namespace GallerySM.Infraestrutura.Mappings
{
    public class CategoriaMap : EntityTypeConfiguration<Assunto>
    {

        public CategoriaMap()
        {
            this.HasKey(e => e.AssuntoId);
            this.ToTable("Categorias");

            this.HasOptional(c => c.ParentAssunto)
               .WithMany(c => c.ChildAssuntos)
               .HasForeignKey(c => c.ParentAssuntoId);


        }
    }
}
