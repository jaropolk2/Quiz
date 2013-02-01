using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GallerySM.Aplicacao.Games;
using GallerySM.Aplicacao.Models.Dominio.ContextosDelimitados.Games.Quiz;

namespace Presentation.UI.Web2.Controllers
{
    public class AssuntoController : Controller 
    {
        private IQuizSetupAplicacao _setupQuiz = null;

        public AssuntoController()
        {
            _setupQuiz = new QuizSetupAplicacao();
        }

        public AssuntoController(IQuizSetupAplicacao quizSetupAplicacao)
        {
            _setupQuiz = quizSetupAplicacao;
        }


        public ViewResult Index()
        {
            _setupQuiz = new QuizSetupAplicacao();      
            ViewBag.AssuntosDisponiveis = _setupQuiz.AssuntosDisponiveis();
            return View("Assuntos");
        }
        
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Nova(AssuntoModel assuntoModel)
        {
            if (!String.IsNullOrEmpty(Request.Form[0]))
                assuntoModel.ParentAssuntoId = Convert.ToInt32(Request.Form[0]);

            _setupQuiz = new QuizSetupAplicacao();
            _setupQuiz.CriaNovoAssunto(assuntoModel);
            return Index();
        }
    }
}
