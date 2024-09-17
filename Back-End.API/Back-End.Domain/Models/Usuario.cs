#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_End.Domain.Models
{
	[Table("Usuario")]
	[Index("Email", Name = "UQ__Usuario__A9D10534BE9615CF", IsUnique = true)]
	public partial class Usuario
	{
		[Key]
		public int CodigoUsuario { get; set; }

		[Required]
		[StringLength(255)]
		[Unicode(false)]
		public string Senha { get; set; }

		[Required]
		[StringLength(255)]
		[Unicode(false)]
		public string Email { get; set; }

		[StringLength(20)]
		public string Telefone { get; set; }

		public DateOnly? DataNascimento { get; set; }

		public int? CodigoGenero { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? DataCriacao { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? UltimoLogin { get; set; }

		[ForeignKey("CodigoGenero")]
		[InverseProperty("Usuarios")]
		public virtual Genero CodigoGeneroNavigation { get; set; }

		[InverseProperty("CodigoUsuarioNavigation")]
		public virtual ICollection<Tarefa> Tarefas { get; set; } = new List<Tarefa>();
	}
}