using Back_End.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Back_End.Infra.Data.Context
{
	public partial class TodoDBContext : DbContext
	{
		public TodoDBContext(DbContextOptions<TodoDBContext> options)
			: base(options)
		{
		}

		public virtual DbSet<Genero> Generos { get; set; }

		public virtual DbSet<StatusTarefa> StatusTarefas { get; set; }

		public virtual DbSet<Tarefa> Tarefas { get; set; }

		public virtual DbSet<Usuario> Usuarios { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Genero>(entity =>
			{
				entity.HasKey(e => e.CodigoGenero).HasName("PK__Genero__4806D4DE3A759DC8");
			});

			modelBuilder.Entity<StatusTarefa>(entity =>
			{
				entity.HasKey(e => e.CodigoStatusTarefa).HasName("PK__StatusTa__530B5E0D90641803");
			});

			modelBuilder.Entity<Tarefa>(entity =>
			{
				entity.HasKey(e => e.CodigoTarefa).HasName("PK__Tarefa__72B4FA61E0D6E553");

				entity.Property(e => e.DataCriacao).HasDefaultValueSql("(getdate())");

				entity.HasOne(d => d.CodigoStatusTarefaNavigation).WithMany(p => p.Tarefas).HasConstraintName("FK__Tarefa__CodigoSt__2E1BDC42");

				entity.HasOne(d => d.CodigoUsuarioNavigation).WithMany(p => p.Tarefas).HasConstraintName("FK__Tarefa__CodigoUs__2D27B809");
			});

			modelBuilder.Entity<Usuario>(entity =>
			{
				entity.HasKey(e => e.CodigoUsuario).HasName("PK__Usuario__F0C18F58C7448923");

				entity.Property(e => e.DataCriacao).HasDefaultValueSql("(getdate())");

				entity.HasOne(d => d.CodigoGeneroNavigation).WithMany(p => p.Usuarios).HasConstraintName("FK__Usuario__CodigoG__276EDEB3");
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}

