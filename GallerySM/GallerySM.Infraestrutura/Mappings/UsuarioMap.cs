using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallerySM.Domain.Domains;

namespace GallerySM.Infraestrutura.Mappings
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {

        public UsuarioMap()
        {
            this.HasKey(u => u.UsuarioId);
            this.ToTable("Usuarios");
           
            this.HasMany(u => u.Exposicoes)
                .WithRequired(e => e.Usuario);

            this.HasOptional(u => u.Galeria)
                .WithRequired(g => g.Usuario);

            this.HasOptional(u => u.AcervoPessoal)
                .WithRequired(a => a.Usuario);


            //this.Property(p => p.CriadoEm).HasColumnType("datetime2")
        }
    }
}
