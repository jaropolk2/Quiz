using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallerySM.Domain.Domains;
using GallerySM.Domain.Games.Quiz;


namespace GallerySM.Domain.Games.Quiz
{
    /// <summary>
    /// Serviço responsável pelas funcionalidades básicas do Quiz
    /// </summary>
    public interface IQuizService
    {
        /// <summary>
        /// Recupera Quiz com base no ID informado
        /// </summary>
        /// <param name="quizId">ID do quiz a ser recuperado</param>
        /// <returns>Quiz sob o ID especificado</returns>
        Quiz RecuperaQuiz(int quizId);

        /// <summary>
        /// Retorna o score do usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        double Score(Usuario usuario);

        /// <summary>
        /// Monta o ranking do Quiz
        /// </summary>
        /// <returns>Uma lista de HistoricosQuiz até a quantidade informada no parâmetro do método</returns>
        IList<Usuario> BuscarRanking(int limite);
    }
}
