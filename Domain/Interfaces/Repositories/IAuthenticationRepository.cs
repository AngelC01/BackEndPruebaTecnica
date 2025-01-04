using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
	public interface IAuthenticationRepository
	{
		Task<Usuario?> LoginAsync(string username, string password);
		//Task<bool> RegisterAsync(Usuario usuario);
		//Task<bool> ValidateTokenAsync(string token);
	}
}
