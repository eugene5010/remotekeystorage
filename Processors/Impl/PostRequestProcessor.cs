using System;
using System.Threading.Tasks;
using RemoteKeyStorage.Services;

namespace RemoteKeyStorage.Processors.Impl
{
	/// <summary>
	/// Процессор для обработки POST запроса.
	/// Целенаправленно инкапсулируем настройку запроса в отдельный от модуля Nancy инстанс класса,
	/// чтобы обеспечить возможность гибкой замены процессора в случае необходимости,
	/// а также чтобы уменьшить привязку к конкретному веб-фреймворку, а также, чтобы уменьшить связность
	/// между этими компонентами и облегчить модульное тестирование
	/// </summary>
	public class PostRequestProcessor : IPostRequestProcessor
	{
		private readonly IRemoteValueCreateService _remoteValueCreateService;

		public PostRequestProcessor(IRemoteValueCreateService remoteValueCreateService)
		{
			_remoteValueCreateService = remoteValueCreateService;
		}

		public Func<dynamic, Task<bool>> ProvidePostItemAction()
		{
			return async args =>
			{
				await _remoteValueCreateService.Create(args.key, args.value);
				return true;
			};
		}

		public string ProvidePostRoute()
		{
			return "/values/{key}/{value}";
		}
	}
}
