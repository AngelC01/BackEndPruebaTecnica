using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using AplicationService.Services;

namespace WebApiAuth.Controllers
{


	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
		private readonly AuthService _authService;
		private readonly IConfiguration _config; // Inyecta la configuración
		public AuthController(AuthService authService, IConfiguration config)
		{
			_authService = authService;
			_config = config;
		}


		[HttpPost("login")]
		public async Task<IActionResult> Login(string username, string password)
		{
			var usuario = await _authService.AutenticarUsuario(username, password);

			if (usuario == null)
			{
				return Unauthorized(new { message = "Credenciales inválidas" });
			}

			var token = GenerarTokenJWT(usuario);

			return Ok(new { token = token });
		}


		private string GenerarTokenJWT(Usuario usuario)
		{
			var claims = new[]
			{
				new Claim(ClaimTypes.Name, usuario.NombreUsuario),
				new Claim(ClaimTypes.NameIdentifier, usuario.Identificador.ToString()), 
			 };

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer: _config["Jwt:Issuer"],
				audience: _config["Jwt:Audience"],
				claims: claims,
				expires: DateTime.Now.AddHours(1), // Tiempo de expiración
				signingCredentials: creds
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

	}
}
