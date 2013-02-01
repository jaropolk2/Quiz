using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GallerySM.Aplicacao.Models.Dominio.ContextosDelimitados.Games.Quiz
{
    public class QuizModel
    {
        public int QuizId { get; set; }
        public int CategoriaId { get; set; }
        public string Descricao { get; set; }
        public bool Disponivel { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime ExpiraEm { get; set; }

        public IList<PerguntaModel> Perguntas { get; set; }        
    }
}