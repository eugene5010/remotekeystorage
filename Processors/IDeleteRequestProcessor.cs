using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteKeyStorage.Processors
{
	/// <summary>
	/// Контракт обработчика запросов DELETE
	/// </summary>
	public interface IDeleteRequestProcessor
	{
		string ProvideDeleteRoute();
		Func<dynamic, Task<bool>> ProvideDeleteItemAction();
	}
}
