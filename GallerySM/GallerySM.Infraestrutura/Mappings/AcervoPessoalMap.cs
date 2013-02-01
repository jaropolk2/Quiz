using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallerySM.Domain.Domains;

namespace GallerySM.Infraestrutura.Mappings
{
    public class AcervoPessoalMap : EntityTypeConfiguration<AcervoPessoal>
    {

        public AcervoPessoalMap()
        {
            this.HasKey(e => e.ID);
            this.ToTable("AcervosPessoais");         

            this.HasMany(a => a.Obras)
                .WithOptional(o => o.AcervoPessoal);
        }
    }
}
