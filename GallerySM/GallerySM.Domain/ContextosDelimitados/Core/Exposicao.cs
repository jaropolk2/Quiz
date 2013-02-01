using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace GallerySM.Domain.Domains
{
    
    public class Exposicao
    {
        public int ID { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public DateTime DataInicio { get; set; }
        
        public DateTime? DataFim { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<Texto> Textos { get; set; }

        public virtual ICollection<Obra> Obras { get; set; }
    }
}
