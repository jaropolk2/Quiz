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
    public class HistoricoQuizMap : EntityTypeConfiguration<HistoricoQuiz>
    {
        public HistoricoQuizMap()
        {
            this.HasKey(k => new { k.QuizId, k.UsuarioId, k.PerguntaId });

            this.ToTable("HistoricosQuiz");

            this.HasRequired(h => h.Pergunta)
                .WithMany(p => p.Historicos)
                .HasForeignKey(f => f.PerguntaId);

            this.HasRequired(h => h.Usuario)
                .WithMany(p => p.HistoricosQuiz)
                .HasForeignKey(f => f.UsuarioId);
            
        }
    }
}
