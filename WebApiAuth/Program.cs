using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Repositories.ContextDatabase;
using System.Text;
using Domain.Interfaces.Repositories;
using Repositories;
using AplicationService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			ValidIssuer = builder.Configuration["Jwt:Issuer"],
			ValidAudience = builder.Configuration["Jwt:Audience"],
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
		};
	});

builder.Services.AddAuthorization();

#endregion

#region ConexionBaseDeDatos
builder.Services.AddDbContext<DbPruebaContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
#endregion

#region AddServices

builder.Services.AddScoped<IAuthenticationRepository, Authentication>();
builder.Services.AddScoped<AuthService>();

#endregion


var AngularSpecificOrigins = "_angularFront";
builder.Services.AddCors(options =>
{
	options.AddPolicy(name: AngularSpecificOrigins,
					  policy =>
					  {
						  policy.WithOrigins("http://localhost:4200")
								.AllowAnyHeader()
								.AllowAnyMethod();
					  });
});

var app = builder.Build();
app.UseCors(AngularSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
