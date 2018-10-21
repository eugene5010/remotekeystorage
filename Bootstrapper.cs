using Microsoft.AspNetCore.Http;
using Nancy;
using Nancy.TinyIoc;
using RemoteKeyStorage.Modules;
using RemoteKeyStorage.Persistence;
using RemoteKeyStorage.Processors;
using RemoteKeyStorage.Processors.Impl;
using RemoteKeyStorage.Services;
using RemoteKeyStorage.Services.Impl;

namespace RemoteKeyStorage
{
	/// <summary>
	/// Настройка и регистрация зависимостей для Nancy
	/// </summary>
	public class Bootstrapper : DefaultNancyBootstrapper
	{
		protected override void ConfigureApplicationContainer(TinyIoCContainer container)
		{
			//Nancy нативный IoC Container предоставляет собой достаточно убогую реализацию, поэтому
			//ограничимся простой регистрацией конкретных имплементаций необходимых нам интерфейсов
			container.Register<IRemoteValueGetService, RemoteValueGetService>().AsMultiInstance();
			container.Register<IRemoteValueCreateService, RemoteValueCreateService>().AsMultiInstance();
			container.Register<IRemoteValueDeleteService, RemoteValueDeleteService>().AsMultiInstance();
			container.Register<IKeyValueStorage, KeyValueStorageDictionary>().AsSingleton();
			container.Register<IGetRequestProcessor, GetRequestProcessor>().AsMultiInstance();
			container.Register<IPostRequestProcessor, PostRequestProcessor>().AsMultiInstance();
			container.Register<IDeleteRequestProcessor, DeleteRequestProcessor>().AsMultiInstance();
			container.Register<IHelpProvider, HelpProvider>();
			container.Register<IHttpContextAccessor, HttpContextAccessor>().AsSingleton();
		}
	}
}
