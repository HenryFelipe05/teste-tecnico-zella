namespace Back_End.Application.Queries
{
	public class TarefaQuery
	{
		public int CodigoTarefa { get; set; }
		public int CodigoUsuario { get; set; }
		public string? NomeTarefa { get; set; }
		public string? DescricaoTarefa { get; set; }
		public int CodigoStatusTarefa { get; set; }
	}
}
