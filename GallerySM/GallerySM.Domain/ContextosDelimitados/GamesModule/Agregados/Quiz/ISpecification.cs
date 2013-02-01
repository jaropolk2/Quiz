using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GallerySM.Domain.ContextosDelimitados.GamesModule.Agregados.Quiz;
using GallerySM.Domain.Domains;

namespace GallerySM.Domain.Games.Quiz.Specifications
{
    public interface ISpecification
    {
        bool IsSatisfiedBy();
    }

    public class PerguntaNaoPossuiUmaRespostaCorretaException : Exception
    {
        public PerguntaNaoPossuiUmaRespostaCorretaException()            
        { }
        public PerguntaNaoPossuiUmaRespostaCorretaException(string mensagem)
            : base(mensagem)
        { }
    }

    public class PerguntaDeveTerCincoRespostasException : Exception
    {
        public PerguntaDeveTerCincoRespostasException()            
        { }
        public PerguntaDeveTerCincoRespostasException(string mensagem)
            : base(mensagem)
        { }
    }
    public class PerguntaPossuiUmaRespostaCorretaSpecification : ISpecification
    {
        IList<Resposta> _listaRespostas = null;
        public PerguntaPossuiUmaRespostaCorretaSpecification(IList<Resposta> listaRespostas)
        {
            _listaRespostas = listaRespostas;
        }
        public bool IsSatisfiedBy()
        {
            if (_listaRespostas.Any(r => r.Correta))
                return true;
            else
                throw new PerguntaNaoPossuiUmaRespostaCorretaException("Você deve especificar qual é a resposta correta!");
        }
    }

    public class QuantidadeDeRespostasDiferenteDoAcordadoException : Exception
    {
        public QuantidadeDeRespostasDiferenteDoAcordadoException(string mensagem)
            : base(mensagem)
        { }
    }
    public class QuantidadeDeRespostasSuficientesParaPerguntaSpecification : ISpecification
    {
        IList<Resposta> _listaRespostas = null;
        int _quantidade = 0;
        public QuantidadeDeRespostasSuficientesParaPerguntaSpecification(int quantidade, IList<Resposta> listaRespostas)
        {
            _listaRespostas = listaRespostas;
            _quantidade = quantidade;
        }
        public bool IsSatisfiedBy()
        {
            if (_listaRespostas.Count == _quantidade)
                return true;
            else
                throw new QuantidadeDeRespostasDiferenteDoAcordadoException("Quantidade de respostas diferente do acordado!");

        }
    }

    public class TodasAsRespostasPossuemEnunciado : ISpecification
    {
        IList<Resposta> _listaRespostas = null;

        public TodasAsRespostasPossuemEnunciado(IList<Resposta> listaRespostas)
        {
            _listaRespostas = listaRespostas;
        }
        public bool IsSatisfiedBy()
        {

            foreach (var resposta in _listaRespostas)
                if (String.IsNullOrEmpty(resposta.Descricao))
                    throw new AlgumaRespostaNaoPossuiEnunciadoException();

            return true;
        }
    }
    public class QuantidadeDePerguntasSuficientesParaQuiz : ISpecification
    {
        private int _quantidadeMaxima = 0;
        private IList<Pergunta> _perguntasSelecionadas = new List<Pergunta>();

        public QuantidadeDePerguntasSuficientesParaQuiz(int quantidadeMaxima, IList<Pergunta> perguntasSelecionadas)
        {
            _quantidadeMaxima = quantidadeMaxima;
            _perguntasSelecionadas = perguntasSelecionadas;
        }

        public bool IsSatisfiedBy()
        {
            if (_perguntasSelecionadas.Count == _quantidadeMaxima)
                return true;
            else
                return false;
        }
    }

    public class RespostaCorretaSpecification : ISpecification
    {
        private Pergunta _perguntaRespondida = null;
        private Resposta _respostaSugerida = null;
        public RespostaCorretaSpecification(Pergunta perguntaRespondida, Resposta respostaSugerida)
        {
            _respostaSugerida = respostaSugerida;
            _perguntaRespondida = perguntaRespondida;
        }
        public bool IsSatisfiedBy()
        {
            if (_perguntaRespondida.PossiveisRespostas.Any(r => r.RespostaId == _respostaSugerida.RespostaId && r.Correta))
                return true;
            else
                return false;
        }
    }


    public class PerguntaNaoRespondidaPeloUsuarioSpecification : ISpecification
    {
        private Pergunta _pergunta = null;
        private Usuario _usuario = null;

        public PerguntaNaoRespondidaPeloUsuarioSpecification(Pergunta pergunta, Usuario usuario)
        {
            _pergunta = pergunta;
            _usuario = usuario;
        }

        public bool IsSatisfiedBy()
        {
            //var historicoToCompare = new HistoricoQuiz()
            //{
            //    UsuarioId = _usuario.UsuarioId,
            //    PerguntaId = _pergunta.PerguntaId
            //};

            if (_usuario.HistoricosQuiz.Any(h => h.UsuarioId == _usuario.UsuarioId && h.PerguntaId == _pergunta.PerguntaId))
                return false;
            else
                return true;
        }
    }


    public class NovaCategoriaSpecification : ISpecification
    {
        private IList<Assunto> _categoriasExistentes = null;
        private Assunto _categoriaNova = null;

        public NovaCategoriaSpecification(Assunto categoriaNova, IList<Assunto> categoriasExistentes)
        {
            _categoriaNova = categoriaNova;
            _categoriasExistentes = categoriasExistentes;
        }

        public bool IsSatisfiedBy()
        {
            if (_categoriaNova == null)
                throw new NovasCategoriasSpecificationException("As categorias devem ser informadas!");

            if (_categoriasExistentes.Count() == 0)
                throw new NovasCategoriasSpecificationException("As categorias devem ser informadas!");

            if (_categoriasExistentes.Any(c => c.Name.Equals(_categoriaNova.Name)))
                throw new NovasCategoriasSpecificationException(string.Format("A categoria {0} já está cadastrada! Reveja suas categorias e tente novamente!", _categoriaNova.Name));
            
            return true;
        }
    }

    public class NovasCategoriasSpecificationException : Exception
    {
        public NovasCategoriasSpecificationException(string mensagem)
            : base(mensagem)
        { }
    }
    public class NovasCategoriasSpecification : ISpecification
    {
        private IList<Assunto> _categoriasNovas = null;
        private IList<Assunto> _categoriasExistentes = null;

        public NovasCategoriasSpecification(IList<Assunto> categoriasNovas, IList<Assunto> categoriasExistentes)
        {
            _categoriasNovas = categoriasNovas;
            _categoriasExistentes = categoriasExistentes;
        }

        public bool IsSatisfiedBy()
        {
            if (_categoriasNovas == null)
                throw new NovasCategoriasSpecificationException("As categorias devem ser informadas!");

            if (_categoriasNovas.Count() == 0)
                throw new NovasCategoriasSpecificationException("As categorias devem ser informadas!");

            foreach (var categoriaExistente in _categoriasExistentes)
            {
                if (_categoriasNovas.Any(c => c.Name.Equals(categoriaExistente.Name)))
                    throw new NovasCategoriasSpecificationException(string.Format("A categoria {0} já está cadastrada! Reveja suas categorias e tente novamente!", categoriaExistente.Name));
            }

            return true;
        }
    }



}
