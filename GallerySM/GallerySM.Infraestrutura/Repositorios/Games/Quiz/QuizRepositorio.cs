using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallerySM.Domain.Domains;
using GallerySM.Domain.Domains.Games.Quiz;
using GallerySM.Domain.Games.Quiz;
using GallerySM.Domain.Games.Quiz.Repositorios;
using GallerySM.Infraestrutura.Interfaces;

namespace GallerySM.Infraestrutura.Concrets
{
    public class QuizRepositorio : IRepositorioQuiz
    {
        private IUnitOfWork _unitOfWork = null;
        
        public QuizRepositorio(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }
        
        public void Salva(Pergunta pergunta)
        {
            _unitOfWork.Contexto.Perguntas.Add(pergunta);
            _unitOfWork.Contexto.SaveChanges();
        }
        public void Salva(Quiz quiz)
        {
            _unitOfWork.Contexto.Quizzes.Add(quiz);
            _unitOfWork.Contexto.SaveChanges();
        }

        public IList<HistoricoQuiz> BuscaHistorico(Usuario usuario)
        {
            return _unitOfWork.Contexto.Usuarios.Where(u => u.UsuarioId == usuario.UsuarioId).FirstOrDefault().HistoricosQuiz.ToList();
        }

        public IList<Pergunta> Perguntas()
        {
            var perguntas = _unitOfWork.Contexto.Perguntas.ToList();
            foreach (var pergunta in perguntas)
                _unitOfWork.Contexto.Entry<Pergunta>(pergunta).Collection<Resposta>(r => r.PossiveisRespostas).Load();
            return perguntas;
        }

        public IList<Assunto> ListaCategoriasExistentes()
        {
            return _unitOfWork.Contexto.Categorias.ToList();
        }

        public void Salva(Assunto categoria)
        {
            _unitOfWork.Contexto.Categorias.Add(categoria);
            _unitOfWork.Contexto.SaveChanges();
        }
        public void Salva(IList<Assunto> categorias)
        {
            foreach (var categoria in categorias)
                _unitOfWork.Contexto.Categorias.Add(categoria);
            _unitOfWork.Contexto.SaveChanges();
        }

        public IList<Usuario> Ranking(int quantidade)                                                                                                                                                                                                                                                                                                                   
        {
            //return _unitOfWork.Contexto.Usuarios
            //    .OrderBy(u => u.HistoricosQuiz
            //        .Where(h => h.Completou)
            //        .Count(h => h.Quiz.Perguntas.Where(p => p.PossiveisRespostas))
            //        .ToList();            

            throw new NotImplementedException();
        }


        public IList<Assunto> AssuntosDeQuizzesDisponiveisPara(int usuarioId)
        {
            return _unitOfWork.Contexto.Quizzes
                .Where(q => q.Disponivel && q.ExpiraEm >= DateTime.Now && q.Historicos.Count(h => h.UsuarioId == usuarioId) < 10 && q.Perguntas.Count() == 10)
                .Select(q => q.Categoria).ToList();
        }


        public Quiz RecuperarPorCategoria(int categoriaId)
        {
            return _unitOfWork.Contexto.Quizzes
                .OrderByDescending(q => q.CriadoEm)
                .FirstOrDefault(q => q.CategoriaId == categoriaId && q.Disponivel && q.ExpiraEm >= DateTime.Now && q.Perguntas.Count() == 10);
        }

        public Quiz RecuperaPorId(int quizId)
        {
            return _unitOfWork.Contexto.Quizzes                
                .FirstOrDefault(q => q.QuizId == quizId);
        }


        public IList<Quiz> DisponiveisParaAssociarPerguntas()
        {
            return _unitOfWork.Contexto.Quizzes
               .Where(q => q.Perguntas.Count() < 10).ToList();
        }
    }
}
