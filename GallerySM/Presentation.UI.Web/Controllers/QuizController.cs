using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GallerySM.Aplicacao.Games;
using GallerySM.Aplicacao.Models.Dominio.ContextosDelimitados.Core;
using GallerySM.Aplicacao.Models.Dominio.ContextosDelimitados.Games.Quiz;
using GallerySM.Domain.Domains;
using GallerySM.Domain.Domains.Games.Quiz;
using GallerySM.Domain.Games.Quiz;

namespace Presentation.UI.Web.Controllers
{
    public class QuizController : Controller
    {
        private IQuizAplicacao _quizAplicacao = null;
        const int __MAX__ = 10;
        const int __PAGE_SIZE__ = 1;

        protected QuizModel Quiz { get; set; }

        public QuizController()
        { }

        public QuizController(IQuizAplicacao quizAplicacao)
        {
            _quizAplicacao = quizAplicacao;
        }

        public ActionResult Index()
        {
            IList<AssuntoModel> assuntos = null;
            using (_quizAplicacao = new QuizAplicacao())
            {
                assuntos = _quizAplicacao.AssuntosDeQuizzesDisponiveisPara(new UsuarioModel() { UsuarioId = 1});
            }
            return View("Assuntos", assuntos);
        }

        public ViewResult List(int id)
        {
            PerguntaModel pergunta = null;
            using (_quizAplicacao = new QuizAplicacao())
            {
                this.Quiz = _quizAplicacao.Start(new AssuntoModel() { AssuntoId = id });
                pergunta = Quiz.Perguntas
                .OrderBy(p => p.PerguntaId)
                .Skip((id - 1) * __PAGE_SIZE__)
                .Take(__PAGE_SIZE__).FirstOrDefault();
                return View("Quiz", pergunta);
            }
        }


        public ActionResult Responde(int quizId, int perguntaId, int respostaId)
        {
            var quizModel = new QuizModel() { QuizId = quizId };
            var perguntaModel = new PerguntaModel() { PerguntaId = perguntaId };
            var respostaModel = new RespostaModel() { RespostaId = respostaId };
            var usuarioModel = new UsuarioModel() {UsuarioId = 1};

            using (_quizAplicacao = new QuizAplicacao())
            {
                if (_quizAplicacao.IsCorreta(quizModel,usuarioModel,perguntaModel,respostaModel))
                    return View("YES! =]");
                else
                    return View("NOOOOOOOOOOOOOOOO... :((((((((((((");
            }
        }

        public ActionResult Score(UsuarioModel usuario)
        {
            return View(_quizAplicacao.Score(usuario));
        }

        public ActionResult Ranking()
        {
            return View(_quizAplicacao.BuscarRanking(__MAX__));
        }
    }
}
