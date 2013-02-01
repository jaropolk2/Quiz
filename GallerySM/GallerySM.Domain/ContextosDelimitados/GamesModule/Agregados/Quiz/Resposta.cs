using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GallerySM.Domain.Games.Quiz
{
    public class Resposta
    {
        public int RespostaId { get; set; }        
        public int PerguntaId { get; set; }
        public bool Correta { get; set; }
        public string Descricao { get; set; }

        public virtual Pergunta Pergunta { get; set; }
    }
}
