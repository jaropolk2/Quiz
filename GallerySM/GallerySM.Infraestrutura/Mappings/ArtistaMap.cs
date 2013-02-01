using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallerySM.Domain.Domains;

namespace GallerySM.Infraestrutura.Mappings
{
    public class ArtistaMap : EntityTypeConfiguration<Artista>
    {

        public ArtistaMap()
        {
            this.HasKey(e => e.ID);
            this.ToTable("Artistas");

            this.HasMany(a => a.Obras)
                .WithRequired(o => o.Artista);

            this.HasMany(a => a.Galerias)
                .WithMany(g => g.Artistas);
        }
    }
}
