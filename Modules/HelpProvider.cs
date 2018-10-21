using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Nancy;

namespace RemoteKeyStorage.Modules
{
	/// <summary>
	/// Примитивный провайдер документации
	/// </summary>
	public class HelpProvider : IHelpProvider
	{
		public string GetHelp(Func<NancyContext> httpContextProvider)
		{
			var path = httpContextProvider().Request.Url.SiteBase;
			return $@"Welcome, User! That's a naive help implementation avoid using Swagger. Run GET {path}/values/<somekey>` to get key value or `POST {path}/values/<somekey>/<newvalue>` to insert or update value";
		}
	}
}
