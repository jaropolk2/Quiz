using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GallerySM.Aplicacao.Models.Dominio.ContextosDelimitados.Games.Quiz
{
    public class AssuntoModel
    {
        public int AssuntoId { get; set; }
        public string Name { get; set; }
        public int? ParentAssuntoId { get; set; }
    }
}
