using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallerySM.Domain.Domains;
using System.Data.Entity;
using GallerySM.Infraestrutura.Mappings;
using GallerySM.Domain.Domains.Games;
using GallerySM.Domain.Domains.Games.Quiz;
using GallerySM.Domain.Games.Quiz;
namespace GallerySM.Infraestrutura.Concrets
{

    public class GallerySMContextInitializer : DropCreateDatabaseAlways<GallerySMContext>
    {
        protected override void Seed(GallerySMContext context)
        {
            //TODO: criar índices aqui
            //context.Database.ExecuteSqlCommand("CREATE INDEX IX_Customer_Name ON Customers (Name) ");    
            base.Seed(context);
        }
    }
    public class GallerySMContext : DbContext, IDisposable
    {
       
        public DbSet<AcervoPessoal> AcervosPessoais { get; set; }
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Exposicao> Exposicoes { get; set; }
        public DbSet<Galeria> Galerias { get; set; }
        public DbSet<Obra> Obras { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Texto> Textos { get;set; }
        public DbSet<Pergunta> Perguntas { get; set; }
        public DbSet<Resposta> Respostas { get; set; }
        public DbSet<Assunto> Categorias { get; set; }
        public DbSet<HistoricoQuiz> HistoricosQuiz { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {   
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new TextoMap());
            modelBuilder.Configurations.Add(new ExposicaoMap());
            modelBuilder.Configurations.Add(new GaleriaMap());
            modelBuilder.Configurations.Add(new AcervoPessoalMap());
            modelBuilder.Configurations.Add(new ArtistaMap());
            modelBuilder.Configurations.Add(new ObraMap());
            modelBuilder.Configurations.Add(new PerguntaMap());
            modelBuilder.Configurations.Add(new RespostaMap());
            modelBuilder.Configurations.Add(new CategoriaMap());
            modelBuilder.Configurations.Add(new QuizMap());
            modelBuilder.Configurations.Add(new HistoricoQuizMap());
            base.OnModelCreating(modelBuilder);
            //this.Configuration.LazyLoadingEnabled = false;                 
        }
        protected void Dispose()
        {
            base.Dispose();
        }
    }
}
