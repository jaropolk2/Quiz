using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallerySM.Domain.Domains;
using GallerySM.Domain.Games.Quiz;

namespace GallerySM.Infraestrutura.Mappings
{
    public class PerguntaMap : EntityTypeConfiguration<Pergunta>
    {
        public PerguntaMap()
        {
            this.HasKey(o => o.PerguntaId);
            
            this.ToTable("Perguntas");
           
            
            this.HasMany(p => p.PossiveisRespostas)
                .WithRequired(r => r.Pergunta)
                .HasForeignKey(r => r.PerguntaId);
            

            this.HasMany(p => p.Historicos)
                .WithRequired(h => h.Pergunta)
                .HasForeignKey(p => p.PerguntaId);
        }
    }
}
