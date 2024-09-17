#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Back_End.Domain.Models
{
	[Table("Genero")]
	public partial class Genero
	{
		[Key]
		public int CodigoGenero { get; set; }

		[Required]
		[StringLength(50)]
		[Unicode(false)]
		public string DescricaoGenero { get; set; }

		[InverseProperty("CodigoGeneroNavigation")]
		public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
	}
}