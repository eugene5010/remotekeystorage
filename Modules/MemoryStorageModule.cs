using Nancy;
using RemoteKeyStorage.Processors;

namespace RemoteKeyStorage.Modules
{
	/*
	Приложение представляет собой простейший образец реализации гексагональной/Onion архитектуры 
	см. например https://jeffreypalermo.com/2008/07/the-onion-architecture-part-1/
	в приложении присутствуют следующие слои 
	- инфраструктурный слой (Nancy модуль и все, что связано с обработкой Pipe Line веб-реквеста)
	- слой сервисов уровня приложения (Обработчики запросов, которые модуль Nancy получает инжекцией зависимостей в конструкторе)
	- слой доменных сервисов (Сервисы создания, получения, удаления данных)
	- слой хранилища данных
	Каждый из уровней абстракции обращается только к нижележащей абстракции через инъекцию зависимостей, что позволяет
	уменьшить связность между слоями и позволяет независимо расширять и заменять реализации абстракций каждого слоя
	В серьезном проекте абстракции каждого слоя данных располагаются в собственных сборках, имеющих строго регламентированный набор зависимостей
	К примеру, слой инфраструктуры не может иметь ссылок на слой хранилища данных, и так далее.
	*/
	/// <summary>
	/// Nancy модуль для взаимодействия с хранилищем значений.
	/// Класс целенаправленно сделан закрытым для расширения, во избежание
	/// перекрытия виртуальных методов настройки роутингов запроса и вызова их внутри конструктора,
	/// что может привести к нарушению инварианта состояния модуля.
	/// В общем случае возможна реализация более Generic- варианта модуля с указанием типов ключа и значения.
	/// Данный модуль предельно примитивен, однако в более серьезном случае в нем обязательно появится логика,
	/// не связанная с конкретной сущностью, такая как настройки Before/After, логирование, другие аспекты, которые необходимо
	/// иметь возможность использовать повторно. Поэтому, саму обработку запросов следует вынести в отдельные абстракции,
	/// а на уровне абстракции модуля Nancy оставить лишь аспекты, общие для процесса обработки веб-реквеста
	/// </summary>
	public sealed class MemoryStorageModule : NancyModule
	{
		public MemoryStorageModule(IHelpProvider helpProvider, IGetRequestProcessor getRequestProcessor, IPostRequestProcessor postRequestProcessor, IDeleteRequestProcessor deleteRequestProcessor)
		{
			Get("/", args => helpProvider.GetHelp(() => Context));

			Get(getRequestProcessor.ProvideGetRoute(),  getRequestProcessor.ProvideGetItemAction());
			Post(postRequestProcessor.ProvidePostRoute(), postRequestProcessor.ProvidePostItemAction());
			Delete(deleteRequestProcessor.ProvideDeleteRoute(), deleteRequestProcessor.ProvideDeleteItemAction());
		}
	}
}
