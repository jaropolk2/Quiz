using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallerySM.Domain.Games.Quiz;

namespace GallerySM.Domain.Games.Quiz.Setup
{
    /// <summary>
    /// Serviço de configuração do quiz
    /// </summary>
    public interface IQuizSetup
    {
        /// <summary>
        /// Cria novas categorias
        /// </summary>
        /// <param name="categorias">Categorias a incluir</param>
        void CriaNovasCategorias(IList<Assunto> categorias);

        /// <summary>
        /// Cria nova categoria
        /// </summary>
        /// <param name="categorias">Categoria a incluir</param>
        void CriaNovaCategoria(Assunto categoria);

        /// <summary>
        /// Persiste o Quiz no banco de dados
        /// </summary>
        /// <param name="quiz"></param>
        void Salva(Quiz quiz);


    }
}
