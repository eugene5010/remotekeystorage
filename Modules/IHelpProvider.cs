using System;
using Nancy;

namespace RemoteKeyStorage.Modules
{
	/// <summary>
	/// Примитивный, очень примитивный провайдер документации
	/// </summary>
	public interface IHelpProvider
	{
		string GetHelp(Func<NancyContext> httpContextProvider);
	}
}
