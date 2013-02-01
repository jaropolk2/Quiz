using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GallerySM.Aplicacao.Games;
using GallerySM.Aplicacao.Models.Dominio.ContextosDelimitados.Games.Quiz;

namespace Presentation.UI.Web2.Controllers
{
    public class PerguntasController : Controller
    {
        public PerguntasController()
        {
            ViewBag.Pronto = false;
        }
        private QuizModel QuizSendoConfigurado 
        {
            get { return (QuizModel)Session["QuizSendoConfigurado"]; }
            set { Session["QuizSendoConfigurado"] = value; }
        }


        public ActionResult SalvaQuiz()
        {
            IQuizSetupAplicacao setupAplicacaoQuiz = new QuizSetupAplicacao();
            setupAplicacaoQuiz.CriaNovoQuiz(this.QuizSendoConfigurado);
            return View("Yes! =]");
        }
        public ActionResult NovasPerguntas(QuizModel quizModel)
        {
            this.QuizSendoConfigurado = quizModel;
            return View("QuizSendoConfigurado", this.QuizSendoConfigurado);
        }

        [HttpPost]
        public ViewResult AdicionaNova()
        {
            this.QuizSendoConfigurado.Perguntas.Add(this.GetPergunta());
            if (this.QuizSendoConfigurado.Perguntas.Count() == 10)
                ViewBag.Pronto = true;
            return View("QuizSendoConfigurado", this.QuizSendoConfigurado);
        }

        private PerguntaModel GetPergunta()
        { 
            var pergunta = new PerguntaModel()
            {
                Descricao = Request.Form["descricaoPergunta"].ToString(),
                Dificuldade = Request.Form["dificuldade"].ToString().Equals("Basica") ? 1 : 2
            };
            pergunta.PossiveisRespostas = GetResposta();
            return pergunta;
        }
        private IList<RespostaModel> GetResposta()
        {
            var lista = new List<RespostaModel>();
            for (int i = 1; i <= 5; i++)
            {
                var resposta = new RespostaModel()
                {
                    Descricao = Request.Form["resposta" + i.ToString()].ToString(),
                    Correta = Request.Form[("checkResposta" + i.ToString())].ToString() == "false" ? false : true
                };
                lista.Add(resposta);
            }
            return lista;
        }

    }
}
