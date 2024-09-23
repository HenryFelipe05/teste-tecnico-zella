using System.Security.Claims;

namespace Back_End.Infra
{
	public static class ClaimsPrincipalExtencion
	{
		public static int RecuperarCodigoUsuario(this ClaimsPrincipal usuario)
		{
			return int.Parse(usuario.FindFirst("codigoUsuario").Value);
		}

		public static string RecuperarEmailUsuario(this ClaimsPrincipal usuario)
		{
			return usuario.FindFirst("email").Value;
		}
	}
}
