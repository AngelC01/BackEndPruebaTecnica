using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationService
{
	public class AppResult<T>
	{

		public T Result { get; set; }
		public string Message { get; set; } 

		public AppResult(T Result, string Message) {

			this.Result = Result;
			this.Message = Message;
		}




	}
}
