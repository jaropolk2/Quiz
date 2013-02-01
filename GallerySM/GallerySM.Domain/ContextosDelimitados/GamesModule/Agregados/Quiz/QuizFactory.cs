using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallerySM.Domain.Domains.Games;
using GallerySM.Domain.Domains.Games.Quiz;
using GallerySM.Domain.Games.Quiz.Repositorios;
using GallerySM.Domain.Games.Quiz.Specifications;


namespace GallerySM.Domain.Games.Quiz
{
    public static class QuizFactory
    {  
        public static Quiz CriaQuiz(Assunto categoria, string descricao, DateTime expiraEm, bool isDisponvel)
        {
            var quiz = new Quiz()
            {
                CriadoEm = DateTime.Now,
                Descricao = descricao,
                Disponivel = isDisponvel,
                ExpiraEm = expiraEm,
                Categoria = categoria
            };

            return quiz;
        }
    }
}
