using System;
using System.Threading.Tasks;

namespace RemoteKeyStorage.Processors
{
	/// <summary>
	/// Контракт обработчика POST-запросов
	/// </summary>
	public interface IPostRequestProcessor
	{
		string ProvidePostRoute();
		Func<dynamic, Task<bool>> ProvidePostItemAction();
	}
}
