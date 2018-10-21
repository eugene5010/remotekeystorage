using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RemoteKeyStorage.Persistence;

namespace RemoteKeyStorage.Services.Impl
{
	/// <summary>
	/// Реализация сервиса изменения значения для указанного ключа
	/// </summary>
	public class RemoteValueCreateService : IRemoteValueCreateService
	{
		private readonly IKeyValueStorage _keyValueStorage;

		public RemoteValueCreateService(IKeyValueStorage keyValueStorage)
		{
			_keyValueStorage = keyValueStorage;
		}

		/// <summary>
		/// Сервис создания значений хранилища.
		/// В данном случае мы могли бы напрямую обратиться из обработчика запроса
		/// в code-behind к хранилищу данных, однако, это была бы вариацию на тему одного из
		/// многочисленных порталов в ад, подстерегающих разработчика.
		/// Мы же условились, что реализуем onion архитектуру приложения
		/// </summary>
		public async Task Create(string key, object value)
		{
			await _keyValueStorage.Update(key, value);
		}
	}
}
