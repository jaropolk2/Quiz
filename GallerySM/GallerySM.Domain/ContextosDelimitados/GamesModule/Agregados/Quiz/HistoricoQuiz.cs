using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallerySM.Domain.Domains;

namespace GallerySM.Domain.Games.Quiz
{
    public class HistoricoQuiz 
    {
        public int QuizId { get; set; }
        public int UsuarioId { get; set; }        
        public int PerguntaId { get; set; }        
        public bool Acertou { get; set; }
        public DateTime DataResposta { get; set; }        

        public virtual Usuario Usuario { get; set; }
        public virtual Quiz Quiz { get; set; }
        public virtual Pergunta Pergunta { get; set; }
    }
}
