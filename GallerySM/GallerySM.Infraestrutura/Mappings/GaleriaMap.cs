using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallerySM.Domain.Domains;

namespace GallerySM.Infraestrutura.Mappings
{
    class GaleriaMap : EntityTypeConfiguration<Galeria>
    {
        public GaleriaMap()
        {
            this.HasKey(g => g.GaleriaId);
            this.ToTable("Galerias");

            this.HasMany(g => g.Artistas)
                .WithMany(a => a.Galerias);            

            this.HasMany(g => g.Obras)
                .WithRequired(o => o.Galeria);

        }
    }
}
