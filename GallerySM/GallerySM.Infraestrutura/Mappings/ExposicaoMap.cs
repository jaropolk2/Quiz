using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallerySM.Domain.Domains;

namespace GallerySM.Infraestrutura.Mappings
{
    public class ExposicaoMap : EntityTypeConfiguration<Exposicao>
    {

        public ExposicaoMap()
        {
            this.HasKey(e => e.ID);
            this.ToTable("Exposicoes");

            this.HasRequired(e => e.Usuario)
                .WithMany(u => u.Exposicoes);

            this.HasMany(e => e.Textos)
                .WithRequired(t => t.Exposicao);

            this.HasMany(e => e.Obras)
                .WithOptional(o => o.ExpostaEm);

            

        }
    }
}
