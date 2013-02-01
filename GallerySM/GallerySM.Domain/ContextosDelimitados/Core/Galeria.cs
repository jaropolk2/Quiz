using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace GallerySM.Domain.Domains
{    
    public class Galeria 
    { 
        public int GaleriaId { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }
        
        
        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<Obra> Obras { get; set; }

        public virtual ICollection<Artista> Artistas { get; set; }
 
    }
}
