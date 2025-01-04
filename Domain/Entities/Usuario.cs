using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Usuario
	{

		public int Identificador { get; private set; }
		public string NombreUsuario { get; private set; }
		public string Password { get; private set; }
		public DateTime FechaCreacion { get; private set; }

		public Usuario(string nombreUsuario, string password)
		{

			NombreUsuario = nombreUsuario;
			Password = password;
			FechaCreacion = DateTime.UtcNow;
		}
	}
}
