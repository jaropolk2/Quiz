using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallerySM.Domain.Domains;
using GallerySM.Domain.Domains.Games;
using GallerySM.Domain.Domains.Games.Quiz;
using GallerySM.Domain.Games.Quiz;

namespace GallerySM.Infraestrutura.Mappings
{
    public class RespostaMap : EntityTypeConfiguration<Resposta>
    {
        public RespostaMap()
        {
            this.HasKey(o => o.RespostaId);
            this.ToTable("Respostas");

            this.HasRequired(p => p.Pergunta)
                .WithMany(p => p.PossiveisRespostas)
                .HasForeignKey(p => p.PerguntaId);

            this.Property(p => p.Descricao)
                .HasMaxLength(1000)
                .IsRequired();
        }
    }
}
