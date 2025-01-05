using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationService.Dto
{
	public class UsuarioLoginDto
	{
		public string username { get;set; }
		public string password { get;set; }

		public UsuarioLoginDto(string username,string password)
		{
			this.username = username;
			this.password = password;
		}

	}
}
