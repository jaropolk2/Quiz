using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallerySM.Domain.Domains;

namespace GallerySM.Infraestrutura.Mappings
{
    public class TextoMap : EntityTypeConfiguration<Texto>
    {
        public TextoMap()
        {
            this.HasKey(u => u.ID);
            this.ToTable("Textos");

            this.HasRequired(t => t.Exposicao)
                .WithMany(e => e.Textos);
        }
    }
}
