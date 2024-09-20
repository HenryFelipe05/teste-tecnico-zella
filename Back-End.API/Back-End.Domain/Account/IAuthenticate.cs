namespace Back_End.Domain.Account
{
	public interface IAuthenticate
	{
		Task<bool> AutenticarAsync(string email, string senha);
		Task<bool> UsuarioExiste(string email);
		public string GerarToken(int codigoUsuario, string email);
	}
}
