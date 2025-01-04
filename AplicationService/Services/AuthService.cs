using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationService.Services
{
	public class AuthService
	{
		private readonly IAuthenticationRepository _authenticationRepository;

		public AuthService(IAuthenticationRepository authenticationRepository)
		{
			_authenticationRepository = authenticationRepository;
		}

		public async Task<Usuario> AutenticarUsuario(string username, string password)
		{
			var usuario = await _authenticationRepository.LoginAsync(username, password);

			if (usuario == null)
			{
				return null; // Usuario no encontrado
			}

			return usuario; // Autenticación exitosa
		}




	}
}
