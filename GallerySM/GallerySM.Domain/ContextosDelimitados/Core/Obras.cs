using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace GallerySM.Domain.Domains
{   
    public class Obra
    {
        public int ID { get; set; }
    
        public string Nome { get; set; }

        public string UrlImagem { get; set; }

        public decimal Valor { get; set; }

        public virtual Galeria Galeria { get; set; }

        public virtual Artista Artista { get; set; }

        public virtual Exposicao ExpostaEm { get; set; }

        public virtual AcervoPessoal AcervoPessoal { get; set; }

    }
}
