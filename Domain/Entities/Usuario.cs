using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Usuario
	{

		public int Identificador { get;  set; }
		public string NombreUsuario { get; set; } = "";
		public string Password { get; set; } = "";
		public DateTime FechaCreacion { get;  private set; }

	}
}
