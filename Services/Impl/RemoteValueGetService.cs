using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RemoteKeyStorage.Persistence;

namespace RemoteKeyStorage.Services.Impl
{
	/// <summary>
	/// Реализация сервиса получения значений.
	/// Уровень доступа internal, мы не предполагаем доступа из других сборок иначе,
	/// чем с помощью регистрации интерфейса сервиса.
	/// Класс закрыт для изменений, наследование класса запрещено, т.к. может
	/// привести к смешиванию различных ответственностей. Любое повторное использование реализации
	/// может быть осуществлено только через композицию. Наследование реализации является в большинстве случаев антипаттерном.
	/// Сервис предоставляет асинхронную реализацию доступа к данным. 
	/// </summary>
	internal sealed class RemoteValueGetService : IRemoteValueGetService
	{
		private readonly IKeyValueStorage _keyValueStorage;

		public RemoteValueGetService(IKeyValueStorage keyValueStorage)
		{
			_keyValueStorage = keyValueStorage;
		}

		public async Task<object> Get(string key)
		{
			return await _keyValueStorage.Read(key);
		}
	}
}
