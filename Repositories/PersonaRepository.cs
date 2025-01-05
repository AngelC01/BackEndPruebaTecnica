using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Repositories.ContextDatabase;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public class PersonaRepository : IRepository<Persona>
	{

		private readonly DbPruebaContext _context;
		private readonly DbSet<Persona> _dbSet;

		public PersonaRepository(DbPruebaContext context)
		{
			_context = context;
			_dbSet = _context.Set<Persona>();
		}


		public async Task AddAsync(Persona entity)
		{

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Id", entity.Identificador),
				new SqlParameter("@Nombres", entity.Nombres),
				new SqlParameter("@Apellidos", entity.Apellidos),
				new SqlParameter("@NumeroIdentificacion", entity.NumeroIdentificacion),
				new SqlParameter("@Email", entity.Email),
				new SqlParameter("@TipoIdentificacion", entity.TipoIdentificacion)
			};

			await _context.Database.ExecuteSqlRawAsync("EXEC dbo.Ins_Personas @Id, @Nombres, @Apellidos, @NumeroIdentificacion, @Email, @TipoIdentificacion", parameters);


		}

		public async Task DeleteAsync(int id)
		{
			var entity = await _dbSet.FindAsync(id);
			if (entity != null)
			{
				_dbSet.Remove(entity);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<List<Persona>> GetAllAsync()
		{
			var personas=_dbSet.FromSqlRaw("EXEC dbo.ConsultarPersonas").ToImmutableList().ToList();
			return await Task.FromResult(personas);
		}

		public async Task<Persona> GetByIdAsync(int id)
		{
			return await _dbSet.FindAsync(id);
		}

		public async Task UpdateAsync(Persona entity)
		{
			SqlParameter[] parameters = new SqlParameter[]
{
				new SqlParameter("@Id", entity.Identificador),
				new SqlParameter("@Nombres", entity.Nombres),
				new SqlParameter("@Apellidos", entity.Apellidos),
				new SqlParameter("@NumeroIdentificacion", entity.NumeroIdentificacion),
				new SqlParameter("@Email", entity.Email),
				new SqlParameter("@TipoIdentificacion", entity.TipoIdentificacion)
};

			await _context.Database.ExecuteSqlRawAsync("EXEC dbo.Ins_Personas @Id, @Nombres, @Apellidos, @NumeroIdentificacion, @Email, @TipoIdentificacion", parameters);

		}
	}
}
