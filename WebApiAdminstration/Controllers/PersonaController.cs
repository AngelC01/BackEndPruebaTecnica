using AplicationService;
using AplicationService.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace WebApiAdminstration.Controllers
{

	[ApiController]
	[Route("api/[controller]")]
	public class PersonaController : ControllerBase
	{
		private readonly PersonaService _personaService;
		private readonly IConfiguration _config;

		public PersonaController(PersonaService personaService, IConfiguration config)
		{
			_personaService = personaService;
			_config = config;
		}

		[HttpGet]
		[Authorize]
		public async Task<AppResult<List<Persona>>> GetPersonas()
		{
			var result = await _personaService.ObtenerTodosLasPersonas();
			return result;
		}

		[HttpGet("{id}")]
		[Authorize]
		public async Task<AppResult<Persona>> GetPersona(int id)
		{
			var result = await _personaService.ObtenerPersonaPorId(id);

			return result;
		}

		[HttpPost]
		[Authorize]
		public async Task<AppResult<bool>> PostPersona(Persona persona)
		{
			var result = await _personaService.CrearPersona(persona);
			return result;
		}

		[HttpPut]
		[Authorize]
		public async Task<AppResult<bool>> PutUsuario(Persona persona)
		{

			var result = await _personaService.ActualizarPersona(persona);
			return result;

		}

		[HttpDelete("{id}")]
		[Authorize]
		public async Task<AppResult<bool>> DeleteUsuario(int id)
		{
			var result = await _personaService.EliminarPersona(id);
			return result;


		}
	}
}
