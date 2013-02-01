using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GallerySM.Domain.Domains
{
    public class Texto
    {
        public int ID { get; set; }

        public int Ordem { get; set; }

        public string Conteudo { get; set; }

        public virtual Exposicao Exposicao { get; set; }
    }
}
