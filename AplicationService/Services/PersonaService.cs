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
	public class PersonaService
	{
		private readonly IRepository<Persona> _personaRepository;
		public PersonaService(IRepository<Persona> personaRepository)
		{
			_personaRepository = personaRepository;
		}

		public async Task<AppResult<Persona>> ObtenerPersonaPorId(int id)
		{
			var persona = await _personaRepository.GetByIdAsync(id);
			return await Task.FromResult(new AppResult<Persona>(persona, ""));

		}

		public async Task<AppResult<List<Persona>>> ObtenerTodosLasPersonas()
		{
			var personas = await _personaRepository.GetAllAsync();
			return await Task.FromResult(new AppResult<List<Persona>>(personas, ""));
		}

		public async Task<AppResult<bool>> CrearPersona(Persona usuario)
		{
			await _personaRepository.AddAsync(usuario);
			return await Task.FromResult(new AppResult<bool>(true, "Persona Creada exitosamente"));
		}

		public async Task<AppResult<bool>> ActualizarPersona(Persona persona)
		{
			await _personaRepository.UpdateAsync(persona);
			return await Task.FromResult(new AppResult<bool>(true, "Persona actualizada exitosamente"));

		}

		public async Task<AppResult<bool>> EliminarPersona(int id)
		{
			var persona = await _personaRepository.GetByIdAsync(id);
			if (persona == null)
			{
				return await Task.FromResult(new AppResult<bool>(false, "Persona no encontrada"));
			}
			await _personaRepository.DeleteAsync(id);
			return await Task.FromResult(new AppResult<bool>(true, "Persona eliminado exitosamente"));

		}
	}
}
