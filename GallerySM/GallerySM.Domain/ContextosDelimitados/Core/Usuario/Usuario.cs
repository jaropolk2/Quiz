using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using GallerySM.Domain.Games.Quiz;


namespace GallerySM.Domain.Domains
{   
    
    public class Usuario
    {       
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }        
        public DateTime? UltimoLogin { get; set; }
        public DateTime CriadoEm { get; set; }
        public string Email { get; set; }        
        public decimal Efige { get; set; }
        
        
        public virtual AcervoPessoal AcervoPessoal { get; set; }
        public virtual ICollection<Exposicao> Exposicoes { get; set; }
        public virtual Galeria Galeria { get; set; }
        public virtual ICollection<HistoricoQuiz> HistoricosQuiz { get; set; }
   
    }
}
