using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallerySM.Aplicacao.Models.Dominio.ContextosDelimitados.Core;
using GallerySM.Aplicacao.Models.Dominio.ContextosDelimitados.Games.Quiz;
using GallerySM.Domain.Games.Quiz;

namespace GallerySM.Aplicacao.Games
{
    public interface IQuizAplicacao : IDisposable
    {
        /// <summary>
        /// Lista as categorias dos Quizzes disponiveis para o usuário
        /// </summary>
        /// <param name="usuarioId">Id do usuário logado no sistema</param>
        /// <returns>Lista de categorias de quizzes</returns>
        IList<AssuntoModel> AssuntosDeQuizzesDisponiveisPara(UsuarioModel usuarioModel);

        /// <summary>
        /// Inicia um Quiz da categoria selecionada
        /// </summary>        
        /// <returns>Um quiz</returns>
        QuizModel Start(AssuntoModel assunto);

        /// <summary>
        /// Responde uma pergunta
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="pergunta"></param>
        /// <param name="resposta"></param>
        bool IsCorreta(QuizModel quiz, UsuarioModel usuario, PerguntaModel pergunta, RespostaModel resposta);

        /// <summary>
        /// Retorna o score do usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        double Score(UsuarioModel usuario);

        /// <summary>
        /// Monta o ranking do Quiz
        /// </summary>
        /// <returns>Uma lista de HistoricosQuiz até a quantidade informada no parâmetro do método</returns>
        IList<HistoricoQuiz> BuscarRanking(int limite);
    }
}
