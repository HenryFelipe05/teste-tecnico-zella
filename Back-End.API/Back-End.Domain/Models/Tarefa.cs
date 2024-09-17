#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_End.Domain.Models
{
	[Table("Tarefa")]
	public partial class Tarefa
	{
		[Key]
		public int CodigoTarefa { get; set; }

		public int? CodigoUsuario { get; set; }

		[Required]
		[StringLength(255)]
		public string NomeTarefa { get; set; }

		[StringLength(500)]
		public string DescricaoTarefa { get; set; }

		public DateOnly DataRealizacao { get; set; }

		public int? CodigoStatusTarefa { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? DataCriacao { get; set; }

		[ForeignKey("CodigoStatusTarefa")]
		[InverseProperty("Tarefas")]
		public virtual StatusTarefa CodigoStatusTarefaNavigation { get; set; }

		[ForeignKey("CodigoUsuario")]
		[InverseProperty("Tarefas")]
		public virtual Usuario CodigoUsuarioNavigation { get; set; }
	}
}