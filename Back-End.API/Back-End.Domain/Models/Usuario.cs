#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
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

		public int? CodigoGenero { get; set; }

		[ForeignKey("CodigoGenero")]
		[InverseProperty("Usuarios")]
		public virtual Genero CodigoGeneroNavigation { get; set; }

		[InverseProperty("CodigoUsuarioNavigation")]
		public virtual ICollection<Tarefa> Tarefas { get; set; } = new List<Tarefa>();

		public static Usuario MapearDadosUsuario(string email, string senha, int? codigoGenero, int? codigoUsuario = null)
		{
			return new Usuario
			{
				CodigoUsuario = codigoUsuario ?? 0,
				Email = email,
				Senha = senha,
				CodigoGenero = codigoGenero
			};
		}

		public static bool ValidarFormatoEmail(string email)
		{
			var regexEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
			return Regex.IsMatch(email, regexEmail);
		}

		public void AlterarSenha(string senha)
		{	
			Senha = senha;
		}
	}
}