#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_End.Domain.Models 
{
	[Table("StatusTarefa")]
	public partial class StatusTarefa
	{
		[Key]
		public int CodigoStatusTarefa { get; set; }

		[Required]
		[StringLength(50)]
		[Unicode(false)]
		public string DescricaoStatusTarefa { get; set; }

		[InverseProperty("CodigoStatusTarefaNavigation")]
		public virtual ICollection<Tarefa> Tarefas { get; set; } = new List<Tarefa>();
	}
}


