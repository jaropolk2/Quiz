using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GallerySM.Aplicacao.Models.Dominio.ContextosDelimitados.Core;
using GallerySM.Aplicacao.Models.Dominio.ContextosDelimitados.Games.Quiz;
using GallerySM.Domain.Domains;
using GallerySM.Domain.Games.Quiz;

namespace GallerySM.Aplicacao.Mappers
{
    public static class MappersExtensions
    {
        private static void CreateMappings()
        {
            Mapper.CreateMap<Usuario, UsuarioModel>();
            Mapper.CreateMap<Quiz, QuizModel>();
            Mapper.CreateMap<Pergunta, PerguntaModel>();
            Mapper.CreateMap<Resposta, RespostaModel>();
            Mapper.CreateMap<Assunto, AssuntoModel>();
        }

        private static void CreateMappings2()
        {
            Mapper.CreateMap<UsuarioModel, Usuario>();
            Mapper.CreateMap<QuizModel, Quiz>();
            Mapper.CreateMap<PerguntaModel, Pergunta>();
            Mapper.CreateMap<RespostaModel, Resposta>();
            Mapper.CreateMap<AssuntoModel, Assunto>();
        }

        public static IList<AssuntoModel> ToModel(this IList<Assunto> assuntos)
        {
            CreateMappings();
            var assuntosModels = new List<AssuntoModel>();
            return Mapper.Map<IList<Assunto>, IList<AssuntoModel>>(assuntos, assuntosModels);
        }

        public static AssuntoModel ToModel(this Assunto assunto)
        {
            CreateMappings();
            var assuntoModel = new AssuntoModel();
            return Mapper.Map<Assunto, AssuntoModel>(assunto, assuntoModel);
        }

        public static Quiz ToDomain(this QuizModel quizModel)
        {
            CreateMappings2();
            var quizNovo = new Quiz();
            return Mapper.Map<QuizModel, Quiz>(quizModel, quizNovo);
        }

        public static Assunto ToDomain(this AssuntoModel assunto)
        {
            CreateMappings2();
            var assuntoNovo = new Assunto();
            return Mapper.Map<AssuntoModel, Assunto>(assunto,assuntoNovo);
        }


        public static UsuarioModel ToModel(this Usuario usuario)
        {
            CreateMappings();
            var usuarioModel = new UsuarioModel();
            return Mapper.Map<Usuario, UsuarioModel>(usuario, usuarioModel);
        }

        public static QuizModel ToModel(this Quiz quiz)
        {
            CreateMappings();
            var quizModel = new QuizModel();
            return Mapper.Map<Quiz, QuizModel>(quiz, quizModel);
        }
        public static IList<QuizModel> ToModel(this IList<Quiz> quizzes)
        {
            CreateMappings();
            var quizModel = new List<QuizModel>();
            return Mapper.Map<IList<Quiz>, IList<QuizModel>>(quizzes, quizModel);
        }
    }
}
