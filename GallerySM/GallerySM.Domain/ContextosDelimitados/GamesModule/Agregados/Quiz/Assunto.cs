using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GallerySM.Domain.Games.Quiz
{
    public class Assunto 
    {
        public int AssuntoId { get; set; }
        public string Name { get; set; }        
        public int? ParentAssuntoId { get; set; }

        public virtual Assunto ParentAssunto { get; set; }
        public virtual ICollection<Assunto> ChildAssuntos { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }
    }
}
