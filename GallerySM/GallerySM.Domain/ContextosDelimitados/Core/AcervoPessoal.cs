using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace GallerySM.Domain.Domains
{
    
    public class AcervoPessoal
    {   
        public int ID { get; set; }        

        public virtual ICollection<Obra> Obras { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
