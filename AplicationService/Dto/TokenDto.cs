﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationService.Dto
{
	public class TokenDto
	{
		
		public int Id { get; set; }
		public string? Usuario { get; set; }
		public string? Password { get; set; }
		public string? Token { get; set; }


	}
}
