using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

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
					context.Response.StatusCode = 401; 
					await context.Response.WriteAsync("Token Invalido");
					return;
				}
			}
			else
			{
			}

			await _next(context);
		}


	}
}
