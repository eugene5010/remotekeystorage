using System;
using System.Threading.Tasks;
using Nancy;
using RemoteKeyStorage.Services;
using HttpStatusCode = Nancy.HttpStatusCode;

namespace RemoteKeyStorage.Processors.Impl
{
	/// <summary>
	/// Процессор обработки запросов на получение данных.
	/// Реализует определенный интерфейс, позволяющий в случае необходимости
	/// быструю замену реализации на другую, что позволяет уменьшить связность с модулем
	/// Nancy и упростить модульное тестирование
	/// </summary>
	public class GetRequestProcessor : IGetRequestProcessor
	{
		private readonly IRemoteValueGetService _getValueService;

		public GetRequestProcessor(IRemoteValueGetService getValueService)
		{
			_getValueService = getValueService;
		}

		public Func<dynamic, Task<object>> ProvideGetItemAction()
		{
			//хочется отметить, что единственное место, где мы можем и должны
			//обращаться к HttpResponse - это уровень процессоров (обработчиков), инкапсулирующих внутри себя логику веб-запроса.
			//Более низкоуровневые абстракции, такие как сервисы и тем более уровень хранилища данных не должны
			//иметь никаких ссылок на веб-специфику (таких как HttpContext запроса, Identity и проч.)
			//Таким образом мы уменьшаем связность слоев и обеспечиваем некое приближение к гексагональной архитектуре
			return async args =>
			{
				var value = await _getValueService.Get(args.key);
				if (value == null)
				{
					var noContentResponse = new Response {StatusCode = HttpStatusCode.NoContent};
					return noContentResponse;
				}

				var response = (Response) value;
				response.StatusCode = HttpStatusCode.OK;
				return response;
			};
		}

		public string ProvideGetRoute()
		{
			return "/values/{key}";
		}
	}
}
