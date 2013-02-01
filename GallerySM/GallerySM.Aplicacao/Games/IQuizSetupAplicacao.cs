using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallerySM.Aplicacao.Models.Dominio.ContextosDelimitados.Games.Quiz;

namespace GallerySM.Aplicacao.Games
{
    /// <summary>
    /// Expõe o comportamento de Setup do Quiz 
    /// </summary>
    public interface IQuizSetupAplicacao
    {
        /// <summary>
        /// Cadastra novo assunto para Quiz
        /// </summary>
        /// <param name="assunto"></param>
        void CriaNovoAssunto(AssuntoModel assuntoModel);        

        /// <summary>
        /// Cria novo Quiz
        /// </summary>
        /// <param name="quizModel"></param>
        void CriaNovoQuiz(QuizModel quizModel);

        /// <summary>
        /// Busca todos os assuntos cadastratos
        /// </summary>
        /// <returns></returns>
        IList<AssuntoModel> AssuntosDisponiveis();

        /// <summary>
        /// Buscar Quiz disponiveis para associar perguntas
        /// </summary>
        /// <returns></returns>
        IList<QuizModel> DisponiveisParaAssociarPerguntas();
        
    }
}
