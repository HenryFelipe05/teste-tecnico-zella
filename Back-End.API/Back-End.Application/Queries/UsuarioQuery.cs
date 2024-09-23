using Back_End.Domain.Models;

namespace Back_End.Application.Queries
{
    public class UsuarioQuery
    {
        public int CodigoUsuario { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public int? CodigoGenero { get; set; }

		public static UsuarioQuery MapearParaUsuarioQuery(Usuario usuario)
		{
			return new UsuarioQuery
			{
				CodigoUsuario = usuario.CodigoUsuario,
				Email = usuario.Email,
				Senha = usuario.Senha,
				CodigoGenero = usuario.CodigoGenero,
			};
		}
	}
}
