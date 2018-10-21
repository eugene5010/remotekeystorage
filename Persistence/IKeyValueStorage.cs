using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteKeyStorage.Persistence
{
	/// <summary>
	/// Интерфейс хранилища данных слоя хранения данных
	/// В случае серьезных задач рекомендуется применение шаблона QueryObject,
	/// обеспечивающего лучшую изоляцию уровня слоя сохранения данных.
	/// Предполагается использование хранилища, предоставляющего асинхронные методы доступа к данным
	/// </summary>
	public interface IKeyValueStorage
	{
		Task<object> Read(string key);
		Task Update(string key, object value);
		Task<bool> Delete(string key);
	}
}
