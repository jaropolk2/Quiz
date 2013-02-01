using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GallerySM.Aplicacao.Models.Dominio.ContextosDelimitados.Core;
using GallerySM.Aplicacao.Models.Dominio.ContextosDelimitados.Games.Quiz;
using GallerySM.Domain.Domains;
using GallerySM.Domain.Domains.Games.Quiz;
using GallerySM.Domain.Games.Quiz;
using GallerySM.Infraestrutura.Concrets;
using GallerySM.Aplicacao.Mappers;

namespace GallerySM.Aplicacao.Games
{
    /// <summary>
    /// Implementa as funcionalidades do Quiz
    /// </summary>
    public class QuizAplicacao : IQuizAplicacao
    {
        private EFUnitOfWork contexto = null;

        public QuizAplicacao()
        {
            contexto = new EFUnitOfWork(new GallerySMContext());
        }

        public QuizModel Start(AssuntoModel assunto)
        {
            var repositorio = new QuizRepositorio(contexto);
            var quiz = repositorio.RecuperarPorCategoria(assunto.AssuntoId);
            return quiz.ToModel();
        }

        public bool IsCorreta(QuizModel quiz, UsuarioModel usuario, PerguntaModel pergunta, RespostaModel resposta)
        {
            return CorrigeResposta(quiz.QuizId, usuario.UsuarioId, pergunta.PerguntaId, resposta.RespostaId);
        }

        public IList<AssuntoModel> AssuntosDeQuizzesDisponiveisPara(UsuarioModel usuario)
        {   
            var repositorioQuiz = new QuizRepositorio(contexto);
            var assuntos = repositorioQuiz.AssuntosDeQuizzesDisponiveisPara(usuario.UsuarioId);
            return assuntos.ToList().ToModel();
        }

        private bool CorrigeResposta(int quizId, int usuarioid, int perguntaId, int respostaId)
        {
            //repositórios
            UsuarioRepositorio repositorioUsuario = new UsuarioRepositorio(contexto);
            QuizRepositorio repositorio = new QuizRepositorio(contexto);

            //recupera usuário
            Usuario usuarioLocalizado = repositorioUsuario.BuscarUsuario(usuarioid);

            //recupera Quiz, a pergunta e a resposta proposta
            IQuizService serviceQuiz = new QuizService(repositorio);
            Quiz quizLocalizado = serviceQuiz.RecuperaQuiz(quizId);
            Pergunta perguntaLocalizada = quizLocalizado.Perguntas.First(p => p.PerguntaId == perguntaId);
            Resposta respostaLocalizada = perguntaLocalizada.PossiveisRespostas.First(r => r.RespostaId == respostaId);

            //corrige a resposta, gera e retorna o histórico
            HistoricoQuiz historico = quizLocalizado.Responder(usuarioLocalizado, perguntaLocalizada, respostaLocalizada);
            contexto.Save();
            return historico.Acertou;
        }

        public double Score(UsuarioModel usuario)
        {
            throw new NotImplementedException();
        }

        public IList<HistoricoQuiz> BuscarRanking(int limite)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (contexto != null)
                contexto.Dispose();
        }
    }
}
