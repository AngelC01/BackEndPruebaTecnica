using Microsoft.EntityFrameworkCore;
using Repositories.ContextDatabase;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Data;

namespace Repositories
{
	public class Authentication : IAuthenticationRepository
	{
		private readonly DbPruebaContext _context;

		public Authentication(DbPruebaContext context)
		{
			_context = context;
		}

		public async Task<Usuario?> LoginAsync(string username, string password)
		{

			var parametros = new[]
			{
				new SqlParameter("@Username", SqlDbType.VarChar) { Value = username },
				new SqlParameter("@Password", SqlDbType.VarChar) { Value = password }
			};

			var usuario =  _context.Usuarios
					 .FromSqlRaw("EXEC Login @Username, @Password", parametros)
					.AsEnumerable()
					.FirstOrDefault();

			return await Task.FromResult(usuario);
		}
	}
}
