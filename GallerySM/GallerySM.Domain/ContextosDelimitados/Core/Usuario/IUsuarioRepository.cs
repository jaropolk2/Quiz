using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GallerySM.Domain.Domains.Core.Usuarios
{
    /// <summary>
    /// Define as operações entre o domínio e o repositório de usuários
    /// </summary>
    public interface IUsuarioRepository
    {
        Usuario BuscarUsuario(int usuarioId);
        void Salvar(Usuario usuario);
    }
}
