using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallerySM.Domain.Domains;


namespace GallerySM.Domain.Games.Quiz.Repositorios
{
    public interface IRepositorioQuiz
    {
        void Salva(Pergunta pergunta);
        void Salva(IList<Assunto> categorias);
        void Salva(Assunto categorias);
        void Salva(Quiz quiz);

        Quiz RecuperarPorCategoria(int categoriaId);
        Quiz RecuperaPorId(int quizId);
        IList<HistoricoQuiz> BuscaHistorico(Usuario usuario);
        IList<Pergunta> Perguntas();
        IList<Assunto> ListaCategoriasExistentes();
        IList<Assunto> AssuntosDeQuizzesDisponiveisPara(int usuarioId);
        IList<Usuario> Ranking(int quantidade);
        IList<Quiz> DisponiveisParaAssociarPerguntas();
    }
}