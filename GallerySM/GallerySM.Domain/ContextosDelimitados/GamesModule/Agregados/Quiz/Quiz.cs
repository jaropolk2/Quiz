using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallerySM.Domain.Domains;

namespace GallerySM.Domain.Games.Quiz
{
    public class Quiz
    {
        public int QuizId { get; set; }
        public int CategoriaId { get; set; }

        public string Descricao { get; set; }
        public bool Disponivel { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime ExpiraEm { get; set; }

        public virtual Assunto Categoria { get; set; }
        public virtual ICollection<Assunto> Categorias { get; set; }
        public virtual ICollection<Pergunta> Perguntas { get; set; }
        public virtual ICollection<HistoricoQuiz> Historicos { get; set; }

        public Quiz()
        {
            this.Perguntas = new List<Pergunta>();
            this.Categorias = new List<Assunto>();
        }

        public IList<Pergunta> PerguntasAindaNaoRespondidas()
        {
            IList<Pergunta> perguntas = new List<Pergunta>();
            foreach (var pergunta in Perguntas)
                if (!Historicos.Any(p => p.PerguntaId == pergunta.PerguntaId))
                    perguntas.Add(pergunta);

            return perguntas;
        }

        public Pergunta AdicionaPergunta(string enunciado, Dificuldade dificuldade)
        {
            var pergunta = new Pergunta()
            {
                Descricao = enunciado,
                Dificuldade = dificuldade
            };
            this.Perguntas.Add(pergunta);
            return pergunta;
        }

        private bool IsCorreta(Pergunta pergunta, Resposta resposta)
        {
            if (pergunta.PossiveisRespostas.Any(r => r.Correta && r.RespostaId == resposta.RespostaId))
                return true;
            else
                return false;
        }

        private HistoricoQuiz AdicionaHistoricoAoQuiz(Usuario usuario, Pergunta pergunta, bool acertou)
        {
            var historico = new HistoricoQuiz()
            {
                Usuario = usuario,
                Pergunta = pergunta,
                Acertou = acertou,
                DataResposta = DateTime.Now
            };
            this.Historicos.Add(historico);
            return historico;
        }

        public HistoricoQuiz Responder(Usuario usuario, Pergunta pergunta, Resposta resposta)
        {
            HistoricoQuiz historicoCriado = null;
            if (IsCorreta(pergunta, resposta))
            {
                historicoCriado = this.AdicionaHistoricoAoQuiz(usuario, pergunta, true);
            }
            else
            {
                historicoCriado = this.AdicionaHistoricoAoQuiz(usuario, pergunta, false);
            }
            return historicoCriado;
        }
    }
}
