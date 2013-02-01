using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using GallerySM.Domain.Domains;
using System.Collections.Generic;
using GallerySM.Infraestrutura.Concrets;
using GallerySM.Domain.Domains.Games;
using GallerySM.Domain.Domains.Games.Quiz;
using System.Transactions;
using GallerySM.Domain.Domains.Core.Usuarios;
using System.Data.Entity.Validation;
using System.Security.Cryptography;
using System.Text;
using GallerySM.Domain.Games.Quiz;
using GallerySM.Domain.Games.Quiz.Repositorios;
using GallerySM.Domain.Games.Quiz.Setup;

namespace GallerySM.Domain.Tests
{
    [TestClass]
    public class TestesNoContexto
    {
        [TestMethod]
        public void PodeCriarEDeletarOBancodeDados()
        {
            bool conseguiuCriar = false;
            using (var contexto = new GallerySMContext())
            {
                conseguiuCriar = contexto.Database.CreateIfNotExists();
                if (!conseguiuCriar)
                {
                    contexto.Database.Delete();
                    conseguiuCriar = contexto.Database.CreateIfNotExists();
                }
            }
            Assert.IsTrue(conseguiuCriar);
        }

        [TestMethod]
        public void PodeCriarUmNovoUsuario()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "Rafael",
                Sobrenome = "Pires",
                Email = "rafaelpiresm@gmail.com",
                CriadoEm = DateTime.Now
            };

            using (var contexto = new EFUnitOfWork(new GallerySMContext()))
            {
                IUsuarioRepository repositorioUsuarios = new UsuarioRepositorio(contexto);
                repositorioUsuarios.Salvar(usuario);
            }
        }


        [TestMethod]
        public void PodeCadastrarNovasCategorias()
        {
            IList<Assunto> listaCategorias = new List<Assunto>();
            listaCategorias.Add(new Assunto() { Name = "Romantismo" });
            listaCategorias.Add(new Assunto() { Name = "Neoclassicismo" });
            listaCategorias.Add(new Assunto() { Name = "Cubismo" });

            IQuizSetup serviceSetup = null;

            using (var contexto = new EFUnitOfWork(new GallerySMContext()))
            {
                var repositorio = new QuizRepositorio(contexto);
                serviceSetup = new QuizSetup(repositorio);
                serviceSetup.CriaNovasCategorias(listaCategorias);
            }

            listaCategorias = new List<Assunto>();
            listaCategorias.Add(new Assunto() { Name = "Romantismo filha" });
            listaCategorias.Add(new Assunto() { Name = "Neoclassicismo filha" });
            listaCategorias.Add(new Assunto() { Name = "Cubismo filha" });
            using (var contexto = new EFUnitOfWork(new GallerySMContext()))
            {
                var repositorio = new QuizRepositorio(contexto);
                var primeiraCategoria = repositorio.ListaCategoriasExistentes().Where(c => c.AssuntoId == 1).FirstOrDefault();
                foreach (var c in listaCategorias)
                    primeiraCategoria.ChildAssuntos.Add(c);
                contexto.Save();
            }
        }

        [TestMethod]
        public void PodeCriarUmQuizSemPerguntas()
        {
            using (var contexto = new EFUnitOfWork(new GallerySMContext()))
            {
                var repositorio = new QuizRepositorio(contexto);               

                IQuizSetup serviceSetup = new QuizSetup(repositorio);

                Assunto categoria = repositorio.ListaCategoriasExistentes().Where(c => c.AssuntoId == 1).FirstOrDefault();

                Quiz quiz = QuizFactory.CriaQuiz(categoria, "Primeiro quiz", DateTime.Now.AddDays(15), true);


                try
                {
                    serviceSetup.Salva(quiz);                    
                }
                catch (Exception ex)
                {
                    throw ((DbEntityValidationException)ex);
                }

            }
        }

        [TestMethod]
        public void PodeCriarUmQuizSemCategoria()
        {
            using (var contexto = new EFUnitOfWork(new GallerySMContext()))
            {
                var repositorio = new QuizRepositorio(contexto);

                IQuizSetup serviceSetup = new QuizSetup(repositorio);

                Assunto categoria = null;//repositorio.ListaCategoriasExistentes().Where(c => c.CategoriaId == 1).FirstOrDefault();

                Quiz quiz = QuizFactory.CriaQuiz(categoria, "Primeiro quiz", DateTime.Now.AddDays(15), true);


                try
                {
                    serviceSetup.Salva(quiz);
                }
                catch (Exception ex)
                {
                    throw ((DbEntityValidationException)ex);
                }

            }
        }

        [TestMethod]
        public void PodeCriarUmQuizComPerguntas()
        {
            using (var contexto = new EFUnitOfWork(new GallerySMContext()))
            {
                var repositorio = new QuizRepositorio(contexto);

                //IQuizService serviceQuiz = new QuizService(repositorio);

                IQuizSetup serviceSetup = new QuizSetup(repositorio);                

                Assunto categoria = repositorio.ListaCategoriasExistentes().Where(c => c.AssuntoId == 14).FirstOrDefault();

                IList<Resposta> possiveisRespostas = new List<Resposta>();

                Quiz quiz = QuizFactory.CriaQuiz(categoria, "Primeiro quiz", DateTime.Now.AddDays(15), true);
                
                for (int j = 0; j < 10; j++)
                {
                    var pergunta = quiz.AdicionaPergunta("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", Dificuldade.Basico);

                    for (int i = 0; i <= 3; i++)
                        pergunta.AdicionarResposta("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", false);

                    pergunta.AdicionarResposta("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", true);
                }
                try
                {
                    serviceSetup.Salva(quiz);                    
                }
                catch (Exception ex)
                {
                    throw ((DbEntityValidationException)ex);
                }

            }
        }
   

        [TestMethod]
        public void UsuarioPodeResponderUmQuizInteiro()
        {
            using (var contexto = new EFUnitOfWork(new GallerySMContext()))
            {
                Usuario usuarioLocalizado = new UsuarioRepositorio(contexto).BuscarUsuario(1);

                IRepositorioQuiz repositorio = new QuizRepositorio(contexto);
                IQuizService serviceQuiz = new QuizService(repositorio);

                var quiz = serviceQuiz.RecuperaQuiz(3);
                Assert.IsTrue(quiz.Perguntas.Count == 10, "O Quiz não possui 10 perguntas.");
                foreach (var p in quiz.Perguntas)
                {
                    Assert.IsTrue(p.PossiveisRespostas.Count == 5, string.Format("A Pergunta {0} não possui 5 respostas.",p.PerguntaId));
                    var respostaQualquer = p.PossiveisRespostas.FirstOrDefault(r => r.Correta);
                    quiz.Responder(usuarioLocalizado, p, respostaQualquer);
                }

                contexto.Save();
            }
        }
        [TestMethod]
        public void PodeBuscarOsAssuntosDeQuizzesDisponiveis()
        {
            using (var contexto = new EFUnitOfWork(new GallerySMContext()))
            {
                var repositorioQuiz = new QuizRepositorio(contexto);
                var assuntos = repositorioQuiz.AssuntosDeQuizzesDisponiveisPara(1);
                Assert.IsNotNull(assuntos);
                Assert.IsTrue(assuntos.Count > 0);
            }
        }
    }
}
