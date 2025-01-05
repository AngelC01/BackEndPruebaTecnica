using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Repositories.ContextDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public class UsuarioRepository : IRepository<Usuario>
	{

		private readonly DbPruebaContext _context;
		private readonly DbSet<Usuario> _dbSet;

		public UsuarioRepository(DbPruebaContext context)
		{
			_context = context;
			_dbSet = _context.Set<Usuario>();
		}

		public async Task AddAsync(Usuario entity)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				 new SqlParameter("@Id", entity.Identificador),
				 new SqlParameter("@Usuario", entity.NombreUsuario),
				 new SqlParameter("@Pass", entity.Password)
			};
			await _context.Database.ExecuteSqlRawAsync("EXEC Ins_Usuarios @Id, @Usuario, @Pass", parameters);
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

		public async Task<List<Usuario>> GetAllAsync()
		{
			return await _dbSet.ToListAsync();
		}

		public async Task<Usuario> GetByIdAsync(int id)
		{
			return await _dbSet.FindAsync(id);
		}

		public async Task UpdateAsync(Usuario entity)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				 new SqlParameter("@Id", entity.Identificador),
				 new SqlParameter("@Usuario", entity.NombreUsuario),
				 new SqlParameter("@Pass", entity.Password)
			};
			await _context.Database.ExecuteSqlRawAsync("EXEC Ins_Usuarios @Id, @Usuario, @Pass", parameters);
		}
	}
}
