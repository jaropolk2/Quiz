using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GallerySM.Aplicacao.Games;
using GallerySM.Aplicacao.Models.Dominio.ContextosDelimitados.Games.Quiz;

namespace Presentation.UI.Web2.Controllers
{
    public class NovoQuizController : Controller
    {
        private IQuizSetupAplicacao _setupQuiz = null;


        public NovoQuizController()
        { }

        public ActionResult Index()
        {
            _setupQuiz = new QuizSetupAplicacao();
            ViewBag.AssuntosDisponiveis = _setupQuiz.AssuntosDisponiveis().OrderBy(a => a.Name).ToList().AsEnumerable();
            ViewBag.QuizzesDisponiveis = _setupQuiz.DisponiveisParaAssociarPerguntas().OrderBy(q => q.Descricao).ToList();
            return View("NovoQuiz");
        }

        [HttpPost]
        public ActionResult Novo(QuizModel quizModel)
        {
            quizModel.CriadoEm = DateTime.Now;
            quizModel.ExpiraEm = DateTime.Now.AddDays(15);
            _setupQuiz = new QuizSetupAplicacao();
            _setupQuiz.CriaNovoQuiz(quizModel);
            return Index();
        }
    }
}
