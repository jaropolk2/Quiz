using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallerySM.Domain.Domains;

namespace GallerySM.Infraestrutura.Mappings
{
    public class ObraMap : EntityTypeConfiguration<Obra>
    {

        public ObraMap()
        {
            this.HasKey(o => o.ID);
            this.ToTable("Obras");

            //this.HasOptional(o => o.Galeria)
            //    .WithMany(g => g.Obras);

            this.HasRequired(o => o.Artista)
                .WithMany(a => a.Obras);

            this.HasOptional(o => o.ExpostaEm)
                .WithMany(e => e.Obras);

            this.HasOptional(o => o.AcervoPessoal)
                .WithMany(o => o.Obras);
          
        }
    }
}
