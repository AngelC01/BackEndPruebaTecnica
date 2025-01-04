using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.ContextDatabase
{
	public class  DbPruebaContext : DbContext
	{
		public DbSet<Usuario> Usuarios { get; set; }
		//public DbSet<Persona> Personas { get; set; }

		public DbPruebaContext(DbContextOptions<DbPruebaContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Usuario>(entity =>
			{
				entity.HasKey(e => e.Identificador); // Configura "Identificador" como clave primaria
			});

			// Configuración adicional de entidades si es necesario
		}


	}
}
