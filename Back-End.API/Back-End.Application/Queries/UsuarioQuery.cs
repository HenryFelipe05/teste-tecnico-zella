using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_End.Application.Queries
{
	public class UsuarioQuery
	{
        public int CodigoUsuario { get; set; }
        public string? Email { get; set; }
        public int? CodigoGenero { get; set; }
    }
}
