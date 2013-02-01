using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GallerySM.Aplicacao.Models.Dominio.ContextosDelimitados.Games.Quiz
{
    public class RespostaModel
    {
        public int RespostaId { get; set; }
        public int PerguntaId { get; set; }
        public bool Correta { get; set; }
        public string Descricao { get; set; }
    }
}
