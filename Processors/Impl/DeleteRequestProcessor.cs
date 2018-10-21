using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RemoteKeyStorage.Services;

namespace RemoteKeyStorage.Processors.Impl
{
	/// <summary>
	/// Обработчик DELETE запроса
	/// </summary>
	public class DeleteRequestProcessor : IDeleteRequestProcessor
	{
		private readonly IRemoteValueDeleteService _remoteValueDeleteService;

		public DeleteRequestProcessor(IRemoteValueDeleteService remoteValueDeleteService)
		{
			_remoteValueDeleteService = remoteValueDeleteService;
		}

		public string ProvideDeleteRoute()
		{
			return "/values/{key}";
		}

		public Func<dynamic, Task<bool>> ProvideDeleteItemAction()
		{
			return async args => await _remoteValueDeleteService.Delete(args.key);
		}
	}
}
