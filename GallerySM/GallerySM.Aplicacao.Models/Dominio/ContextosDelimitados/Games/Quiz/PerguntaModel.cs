using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GallerySM.Aplicacao.Models.Dominio.ContextosDelimitados.Games.Quiz
{
    public class PerguntaModel
    {
        public int PerguntaId { get; set; }
        public int QuizId { get; set; }
        public string Descricao { get; set; }
        /// <summary>
        /// Indica a dificuldade da pergunta: se básico, ou avançado.
        /// </summary>
        public int Dificuldade { get; set; }        
        /// <summary>
        /// Possíveis respostas para a pergunta
        /// </summary>
        public IList<RespostaModel> PossiveisRespostas { get; set; }

        public PerguntaModel()
        {
            this.PossiveisRespostas = new List<RespostaModel>();
        }  
    }
}
