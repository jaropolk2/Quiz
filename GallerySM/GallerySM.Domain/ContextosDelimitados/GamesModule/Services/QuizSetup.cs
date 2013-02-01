using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallerySM.Domain.ContextosDelimitados.GamesModule.Agregados.Quiz;
using GallerySM.Domain.Games.Quiz;
using GallerySM.Domain.Games.Quiz.Repositorios;
using GallerySM.Domain.Games.Quiz.Setup;
using GallerySM.Domain.Games.Quiz.Specifications;


namespace GallerySM.Domain.Games.Quiz.Setup
{
    public class QuizSetup : IQuizSetup
    {
        private IRepositorioQuiz _repositorio = null;

        public QuizSetup(IRepositorioQuiz repositorio)
        {
            _repositorio = repositorio;
        }

        public void Salva(Quiz quiz)
        {
            foreach(var pergunta in quiz.Perguntas)
            {
                ISpecification possuiCincoRespostas = 
                    new PerguntaDevePossuirCincoRespostas(pergunta, pergunta.PossiveisRespostas.ToList());

                if (possuiCincoRespostas.IsSatisfiedBy())
                    throw new PerguntaDeveTerCincoRespostasException();

                ISpecification possuiUmaRespostaCorreta =
                    new PerguntaPossuiUmaRespostaCorretaSpecification(pergunta.PossiveisRespostas.ToList());

                if (possuiUmaRespostaCorreta.IsSatisfiedBy())
                    throw new PerguntaNaoPossuiUmaRespostaCorretaException();
            }
            
            _repositorio.Salva(quiz);
        }
        
        public void CriaNovasCategorias(IList<Assunto> categorias)
        {
            var categoriasExistentes = _repositorio.ListaCategoriasExistentes();

            ISpecification specification =
                new NovasCategoriasSpecification(categorias, categoriasExistentes);

            if (specification.IsSatisfiedBy())
                _repositorio.Salva(categorias);
        }

        public void CriaNovaCategoria(Assunto categoria)
        {
            var categoriasExistentes = _repositorio.ListaCategoriasExistentes();

            ISpecification specification =
                new NovaCategoriaSpecification(categoria, categoriasExistentes);

            if (specification.IsSatisfiedBy())
                _repositorio.Salva(categoria);
        }
    }

    public class QuantidadeDeRespostasnaoAtendemAEspecificacaoException : Exception 
    { 

    }
    public class PerguntaDevePossuirCincoRespostas : ISpecification
    {
        private Pergunta _pergunta = null;
        private IList<Resposta> _listaRespostas = null;

        public PerguntaDevePossuirCincoRespostas(Pergunta pergunta, IList<Resposta> listaRespostas)
        {
            _pergunta = pergunta;
            _listaRespostas = listaRespostas;
        }

        public bool IsSatisfiedBy()
        {
            if (_listaRespostas.Count == 5)
                return true;
            else
                return false;
            
        }
    }

}
