namespace Back_End.Application.Commands
{
	public class LoginCommand
    {
        public required string Email { get; set; }
		
		public required string Senha { get; set; }
    }
}
