using AplicationService;
using AplicationService.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApiAdminstration.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UsuarioController : ControllerBase
	{
		private readonly UsuarioService _usuarioService;
		private readonly IConfiguration _config;

		public UsuarioController(UsuarioService usuarioService, IConfiguration config)
		{
			_usuarioService = usuarioService;
			_config = config;
		}

		[HttpGet]
		[Authorize]
		public async Task<AppResult<List<Usuario>>> GetUsuarios()
		{
			var usuarios = await _usuarioService.ObtenerTodosLosUsuarios();
			return usuarios;
		}

		[HttpGet("{id}")]
		[Authorize]
		public async Task<AppResult<Usuario>> GetUsuario(int id)
		{
			var result = await _usuarioService.ObtenerUsuarioPorId(id);

			return result;
		}

		[HttpPost]
		[Authorize]
		public async Task<AppResult<bool>> PostUsuario(Usuario usuario)
		{
			var result = await _usuarioService.CrearUsuario(usuario);
			return result;
		}

		[HttpPut]
		[Authorize]
		public async Task<AppResult<bool>> PutUsuario(Usuario usuario)
		{

			var result = await _usuarioService.ActualizarUsuario(usuario);
			return result;

		}

		[HttpDelete("{id}")]
		[Authorize]
		public async Task<AppResult<bool>> DeleteUsuario(int id)
		{
			var result = await _usuarioService.EliminarUsuario(id);
			return result;


		}

	}



}
