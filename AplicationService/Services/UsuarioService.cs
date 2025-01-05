using Domain.Entities;
using Domain.Interfaces.Repositories;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationService.Services
{
	public class UsuarioService
	{
		private readonly IRepository<Usuario> _usuarioRepository;

		public UsuarioService(IRepository<Usuario> usuarioRepository)
		{
			_usuarioRepository =  usuarioRepository;
		}

		public async Task<AppResult<Usuario>> ObtenerUsuarioPorId(int id)
		{
			var usuario= await _usuarioRepository.GetByIdAsync(id);
			return await Task.FromResult(new AppResult<Usuario>(usuario, ""));

		}

		public async Task<AppResult<List<Usuario>>> ObtenerTodosLosUsuarios()
		{
			var usuarios = await _usuarioRepository.GetAllAsync();
			return await Task.FromResult(new AppResult<List<Usuario>>(usuarios, ""));
		}

		public async Task<AppResult<bool>> CrearUsuario(Usuario usuario)
		{
			await _usuarioRepository.AddAsync(usuario);
			return await Task.FromResult(new AppResult<bool>(true, "Usuario Creado exitosamente"));
		}

		public async Task<AppResult<bool>> ActualizarUsuario(Usuario usuario)
		{
			await _usuarioRepository.UpdateAsync(usuario);
			return await Task.FromResult(new AppResult<bool>(true, "Usuario actualizado exitosamente"));

		}

		public async Task<AppResult<bool>> EliminarUsuario(int id)
		{
			var usuario = await _usuarioRepository.GetByIdAsync(id);
			if(usuario == null)
			{
				return await Task.FromResult(new AppResult<bool>(false, "Usuario no encontrado"));
			}
			await _usuarioRepository.DeleteAsync(id);
			return await Task.FromResult(new AppResult<bool>(true, "Usuario eliminado exitosamente"));

		}


	}
}
