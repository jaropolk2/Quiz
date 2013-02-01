using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GallerySM.Aplicacao.Models.Dominio.ContextosDelimitados.Core
{
    public class UsuarioModel
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime? UltimoLogin { get; set; }
        public DateTime CriadoEm { get; set; }
        public string Email { get; set; }
        public decimal Efige { get; set; }
    }
}
