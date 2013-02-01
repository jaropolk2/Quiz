using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallerySM.Domain.ContextosDelimitados.GamesModule.Agregados.Quiz;
using GallerySM.Domain.Domains;
using GallerySM.Domain.Games.Quiz;
using GallerySM.Domain.Games.Quiz.Repositorios;
using GallerySM.Domain.Games.Quiz.Specifications;


namespace GallerySM.Domain.Games.Quiz
{
    public class QuizService : IQuizService
    {
        const int __MAX__ = 10;
        const int __MAX_RESPOSTAS__ = 5;

        private IRepositorioQuiz _repositorioQuiz = null;        

        public QuizService(IRepositorioQuiz repositorio)
        {
            _repositorioQuiz = repositorio;
        }

        public Quiz RecuperaQuiz(int quizId)
        {
            return _repositorioQuiz.RecuperaPorId(quizId);
        }

        public IList<Pergunta> MontaQuiz(Usuario usuario)
        {
            IList<Pergunta> perguntasAMontarOQuiz = new List<Pergunta>();

            var perguntasQuiz = _repositorioQuiz.Perguntas();
            foreach (var pergunta in perguntasQuiz)
            {
                ISpecification specification =
                    new PerguntaNaoRespondidaPeloUsuarioSpecification(pergunta, usuario);
                if (specification.IsSatisfiedBy())
                    perguntasAMontarOQuiz.Add(pergunta);

                specification = new QuantidadeDePerguntasSuficientesParaQuiz(__MAX__, perguntasAMontarOQuiz);

                if (specification.IsSatisfiedBy())
                    break;
            }

            return perguntasAMontarOQuiz;
        }             


        public double Score(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public IList<Usuario> BuscarRanking(int limite)
        {
            return _repositorioQuiz.Ranking(limite);
        }
    }
}
