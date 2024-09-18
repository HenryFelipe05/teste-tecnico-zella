namespace Back_End.Application.Commands
{
	public class TarefaCommand
	{
        public int CodigoUsuario { get; set; }
        public string? NomeTarefa { get; set; }
        public string? DescricaoTarefa { get; set; }
        public int CodigoStatusTarefa { get; set; }
    }
}
