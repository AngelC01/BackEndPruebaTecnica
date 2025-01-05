using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AplicationService;
using Domain.Entities;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace WebApiAdminstration.MiddleWare
{
	public class JwtMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly IConfiguration _configuration;
		public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
		{
			_next = next;
			_configuration = configuration;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(' ').LastOrDefault();
			var optionsJson = new JsonSerializerOptions { WriteIndented = true };
			if (!string.IsNullOrEmpty(token))
			{
				try
				{
					var jwtSettings = _configuration.GetSection("Jwt");
					var secretKey = Encoding.ASCII.GetBytes(jwtSettings["Key"]);

					var tokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidIssuer = jwtSettings["Issuer"],
						ValidateAudience = true,
						ValidAudience = jwtSettings["Audience"],
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(secretKey)
					};

					var tokenHandler = new JwtSecurityTokenHandler();
					var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);

					context.User = new ClaimsPrincipal(principal);
				}
				catch (SecurityTokenValidationException ex)
				{

					AppResult<bool> result = new AppResult<bool>(false, "Token Invalido");

					context.Response.StatusCode = 401;
					context.Response.ContentType = "text/plain";
					var json = JsonSerializer.Serialize(result, optionsJson);
					await context.Response.WriteAsync(json);
					return;
				}
			}
			else
			{
				AppResult<bool> result = new AppResult<bool>(false, "Token Invalido");
				context.Response.StatusCode = 401;
				context.Response.ContentType = "text/plain";
				var json = JsonSerializer.Serialize(result, optionsJson);
				await context.Response.WriteAsync(json);
				return;
			}

			await _next(context);
		}


	}
}
