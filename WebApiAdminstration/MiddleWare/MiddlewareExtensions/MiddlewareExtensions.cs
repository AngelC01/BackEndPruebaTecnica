namespace WebApiAdminstration.MiddleWare.MiddlewareExtensions
{
	public static class MiddlewareExtensions
	{
		public static IApplicationBuilder UseJwtMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<JwtMiddleware>();
		}
	}

}
