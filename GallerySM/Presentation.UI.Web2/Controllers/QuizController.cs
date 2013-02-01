using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GallerySM.Aplicacao.Games;
using GallerySM.Aplicacao.Models.Dominio.ContextosDelimitados.Core;
using GallerySM.Aplicacao.Models.Dominio.ContextosDelimitados.Games.Quiz;

namespace Presentation.UI.Web2.Controllers
{
    public class QuizController : Controller
    {
        const int __PAGE_SIZE__ = 1;
        private IQuizAplicacao _quizAplicacao = null;

        protected QuizModel Quiz
        {
            get { return (QuizModel)Session["quiz"]; }
            set { Session["quiz"] = value; }
        }

        protected PerguntaModel Pergunta
        {
            get { return (PerguntaModel)Session["pergunta"]; }
            set { Session["pergunta"] = value; }
        }

        public QuizController()
        {
            _quizAplicacao = new QuizAplicacao();
        }

        [HttpPost]
        public ViewResult Responde(PerguntaModel pergunta)
        {
            RespostaModel respostaProposta = new RespostaModel() { RespostaId = Convert.ToInt32(Request.Form[0]) };
            bool isCorreta = _quizAplicacao.IsCorreta(this.Quiz, new UsuarioModel() { UsuarioId = 1 }, this.Pergunta, respostaProposta);

            string mensagem = string.Empty;
            if (isCorreta)
                mensagem = "Yes! =]";
            else
                mensagem = "Não, não! Não foi desta vez!";

            var novaPergunta  = this.Next(this.Pergunta.PerguntaId + 1);
            if (novaPergunta != null)
            {
                this.Pergunta = novaPergunta;
                return View("Pergunta", this.Pergunta);
            }
            else
                return View("Game over!");
        }

        private QuizModel CarregaQuiz(int assuntoId)
        {
            if (this.Quiz == null)
            {
                var assuntoModel = new AssuntoModel() { AssuntoId = assuntoId };
                this.Quiz = _quizAplicacao.Start(assuntoModel);
            }
            return this.Quiz;
        }

        public ViewResult NovoQuiz(int id)
        {
            if (this.Quiz == null)   
                this.Quiz = CarregaQuiz(id);

            Pergunta = Quiz.Perguntas
            .OrderBy(p => p.PerguntaId)
            .Skip((id - 1) * __PAGE_SIZE__)
            .Take(__PAGE_SIZE__).FirstOrDefault();

            return View("Pergunta", Pergunta);
        }
        
        private PerguntaModel Next(int id)
        {   
            var pergunta = Quiz.Perguntas
            .OrderBy(p => p.PerguntaId)
            .Skip((id - 1) * __PAGE_SIZE__)
            .Take(__PAGE_SIZE__).FirstOrDefault();

            return pergunta;
        }

        public ActionResult List(int id)
        {
            var pergunta = this.Next(id);
            return View("Pergunta", pergunta);
        }

        public ViewResult Index()
        {
            var assuntos = _quizAplicacao.AssuntosDeQuizzesDisponiveisPara(new UsuarioModel() { UsuarioId = 1 });
            return View("Quiz", assuntos);
        }

    }
}
