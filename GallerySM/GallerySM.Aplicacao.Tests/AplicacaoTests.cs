using System;
using GallerySM.Aplicacao.Games;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using GallerySM.Aplicacao.Models.Dominio.ContextosDelimitados.Games.Quiz;
using GallerySM.Aplicacao.Models.Dominio.ContextosDelimitados.Core;

namespace GallerySM.Aplicacao.Tests
{
    [TestClass]
    public class AplicacaoTests
    {

        [TestMethod]
        public void PodeMapearUmAssunto()
        {
            using (var quizAplicacao = new QuizAplicacao())
            {   
                var assuntos = quizAplicacao.AssuntosDeQuizzesDisponiveisPara(new Models.Dominio.ContextosDelimitados.Core.UsuarioModel() { UsuarioId = 1});
                var assunto = assuntos.FirstOrDefault();
                Assert.IsNotNull(assunto,"O objeto veio nulo!");
                Assert.IsTrue(assunto.AssuntoId > 0,"O ID do assunto voltou menor que 1");
                Assert.IsTrue(!String.IsNullOrEmpty(assunto.Name),"O assunto veio sem descrição!");
            }
        }

        [TestMethod]
        public void PodeMapearUmQuiz()
        {
            using (var quizAplicacao = new QuizAplicacao())
            {
                var quiz = quizAplicacao.Start(new AssuntoModel() { AssuntoId = 1 });
                Assert.IsNotNull(quiz);
            }
        }

        [TestMethod]
        public void PodeCriarUmAssunto()
        {
            IQuizSetupAplicacao setupQuiz = new QuizSetupAplicacao();
            var assuntoModel = new AssuntoModel()
            {
                Name = "Barroco"
            };
            setupQuiz.CriaNovoAssunto(assuntoModel);
        }

        [TestMethod]
        public void PodeJogarQuizEndToEnd()
        {
            using (var quizAplicacao = new QuizAplicacao())
            {
                var usuarioModel = new UsuarioModel()
                {
                    UsuarioId = 1
                };

                var assuntos = quizAplicacao.AssuntosDeQuizzesDisponiveisPara(usuarioModel);

                if (assuntos.Count == 0)
                    Assert.Inconclusive("Não existem assuntos com Quizzes novos para este usuário");

                Assert.IsNotNull(assuntos, "A lista de assuntos veio nula!");

                var quiz = quizAplicacao.Start(new AssuntoModel() { AssuntoId = 14 });

                foreach (var pergunta in quiz.Perguntas)
                {
                    var respostaQualquer = pergunta.PossiveisRespostas.FirstOrDefault(r => r.Correta);
                    Assert.IsTrue(quizAplicacao.IsCorreta(quiz,usuarioModel,pergunta,respostaQualquer));                                        
                }
            }
        }
    }
}
