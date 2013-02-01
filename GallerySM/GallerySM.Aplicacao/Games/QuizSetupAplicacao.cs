using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallerySM.Aplicacao.Models.Dominio.ContextosDelimitados.Games.Quiz;
using GallerySM.Infraestrutura.Concrets;
using GallerySM.Aplicacao.Mappers;
using GallerySM.Domain.Games.Quiz.Setup;
using GallerySM.Domain.Games.Quiz.Repositorios;
using GallerySM.Domain.Games.Quiz;
namespace GallerySM.Aplicacao.Games
{
    public class QuizSetupAplicacao : IQuizSetupAplicacao
    {
        private EFUnitOfWork _contexto = null;
        private IQuizSetup _quizSetup = null;
        private IRepositorioQuiz _repositorio = null;

        public void CriaNovoAssunto(AssuntoModel assuntoModel)
        {
            using (_contexto = new EFUnitOfWork(new GallerySMContext()))
            {
                _repositorio = new QuizRepositorio(_contexto);
                _quizSetup = new QuizSetup(_repositorio);
                _quizSetup.CriaNovaCategoria(assuntoModel.ToDomain());
            }
        }

        public void CriaNovoQuiz(QuizModel quizModel)
        {   
            using (_contexto = new EFUnitOfWork(new GallerySMContext()))
            {
                _repositorio = new QuizRepositorio(_contexto);
                IQuizSetup serviceSetup = new QuizSetup(_repositorio);

                Assunto categoria = _repositorio.ListaCategoriasExistentes().Where(c => c.AssuntoId == quizModel.CategoriaId).FirstOrDefault();                

                Quiz quiz = QuizFactory.CriaQuiz(categoria, quizModel.Descricao, quizModel.ExpiraEm, true);
                foreach (var perguntaModel in quizModel.Perguntas)
                {
                    var pergunta = quiz.AdicionaPergunta(perguntaModel.Descricao, perguntaModel.Dificuldade == 1 ? Dificuldade.Basico : Dificuldade.Avancado);
                    foreach (var respostaModel in perguntaModel.PossiveisRespostas)
                    {
                        pergunta.AdicionarResposta(respostaModel.Descricao, respostaModel.Correta);
                    }
                }
                serviceSetup.Salva(quiz);
            }
        }

        public IList<AssuntoModel> AssuntosDisponiveis()
        {
            using (_contexto = new EFUnitOfWork(new GallerySMContext()))
            {
                _repositorio = new QuizRepositorio(_contexto);                
                return _repositorio.ListaCategoriasExistentes().ToModel();
            }
        }

        public IList<QuizModel> DisponiveisParaAssociarPerguntas()
        {
            using (_contexto = new EFUnitOfWork(new GallerySMContext()))
            {
                _repositorio = new QuizRepositorio(_contexto);
                return _repositorio.DisponiveisParaAssociarPerguntas().ToModel();
            }
        }
    }
}
