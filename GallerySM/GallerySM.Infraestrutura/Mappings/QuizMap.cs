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
    public class QuizMap : EntityTypeConfiguration<Quiz>
    {
        public QuizMap()
        {
            this.HasKey(o => o.QuizId);
            
            this.ToTable("Quiz");           
            
            this.HasMany(p => p.Perguntas)
                .WithRequired(p => p.Quiz)
                .HasForeignKey(p => p.QuizId)
                .WillCascadeOnDelete(false);

            this.HasRequired(p => p.Categoria)
               .WithMany()
               .HasForeignKey(c => c.CategoriaId)
               .WillCascadeOnDelete(false);

            this.HasMany(i => i.Categorias)
            .WithMany(c => c.Quizzes)
            .Map(mc =>
            {
                mc.MapLeftKey("QuizId");
                mc.MapRightKey("CategoriaId");
                mc.ToTable("QuizCategorias");
            });
        }
    }
}
