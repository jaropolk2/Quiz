
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GallerySM.Domain.Domains;
using GallerySM.Domain.Domains.Core.Usuarios;
using GallerySM.Domain.Domains.Games.Quiz;
using GallerySM.Infraestrutura.Interfaces;

namespace GallerySM.Infraestrutura.Concrets
{
    /// <summary>
    /// Implementação do repositório de usuários
    /// </summary>
    public class UsuarioRepositorio : IUsuarioRepository
    {
        private IUnitOfWork _unitOfWork = null;

        public UsuarioRepositorio(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }

        /// <summary>
        /// Busca um usuário por ID
        /// </summary>
        /// <param name="usuarioId">ID do usuário</param>
        /// <returns></returns>
        public Usuario BuscarUsuario(int usuarioId)
       {   
            var usuario = _unitOfWork.Contexto.Usuarios.FirstOrDefault(u => u.UsuarioId == usuarioId);
            //_unitOfWork.Contexto
            //    .Entry<Usuario>(usuario)
            //    .Collection<HistoricoQuiz>("HistoricosQuiz")
            //    .Load();
                
            return usuario;
        }

        /// <summary>
        /// Atualiza um usuário 
        /// </summary>
        /// <param name="usuario"></param>
        public void Salvar(Usuario usuario)
        {
            _unitOfWork.Contexto.Usuarios.Add(usuario);
            _unitOfWork.Save();
        }
    }
}
