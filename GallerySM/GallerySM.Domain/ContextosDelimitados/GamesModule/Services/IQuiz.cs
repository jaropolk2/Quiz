using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallerySM.Domain.Games.Quiz;

namespace GallerySM.Domain.Domains.Games.Quiz
{
    public interface IQuiz
    {
        IList<Pergunta> Perguntas { get; set; }
        void Responder(Pergunta pergunta);
    }
}
