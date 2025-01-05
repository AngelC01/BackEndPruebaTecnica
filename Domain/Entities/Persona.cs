using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Persona
	{
		public int Identificador { get; set; }
		public string Nombres { get; set; } = "";
		public string Apellidos { get; set; } = "";
		public string NumeroIdentificacion { get; set; } = "";
		public string Email { get; set; } = "";
		public string TipoIdentificacion { get; set; } = "";
		public DateTime? FechaCreacion { get; set; }
		public string IdentificacionCompleta => $"{TipoIdentificacion}: {NumeroIdentificacion}";
		public string NombreCompleto => $"{Nombres} {Apellidos}";


	}
}
