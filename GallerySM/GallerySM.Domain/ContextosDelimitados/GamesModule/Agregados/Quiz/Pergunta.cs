using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GallerySM.Domain.Games.Quiz
{  
    public class Pergunta
    {
        public int PerguntaId { get; set; }
        public int QuizId { get; set; }
        public string Descricao { get; set; }
        
        /// <summary>
        /// Indica a dificuldade da pergunta: se básico, ou avançado.
        /// </summary>
        public Dificuldade Dificuldade { get; set; }

        
        public virtual Quiz Quiz { get; set; }
        
        /// <summary>
        /// Possíveis respostas para a pergunta
        /// </summary>
        public virtual ICollection<Resposta> PossiveisRespostas { get; set; }
        
        /// <summary>
        /// Históricos relacionados a esta pergunta
        /// </summary>
        public virtual ICollection<HistoricoQuiz> Historicos { get; set; }

        public Pergunta()
        {
            this.PossiveisRespostas = new List<Resposta>();        
        }

        /// <summary>
        /// Cria uma resposta e já relaciona com a pergunta 
        /// </summary>
        /// <param name="enunciado">Enunciado da resposta</param>
        /// <param name="isCorreta">Indica se é a resposta correta</param>
        /// <returns></returns>
        public Pergunta AdicionarResposta(string enunciado, bool isCorreta)
        {
            var resposta = new Resposta()
            {
                Descricao = enunciado,
                Correta = isCorreta
            };
            this.PossiveisRespostas.Add(resposta);
            return this;
        }
    }
}
