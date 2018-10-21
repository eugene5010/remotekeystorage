using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace RemoteKeyStorage.Persistence
{
	/// <summary>
	/// Наивная имплементация хранилища ключей и значений на основе ConcurrentDictionary
	/// Использование общего состояния на уровне приложения является антипаттерном.
	/// В общем случае, хранение InMemory данных лучше перенести во внешнюю зависимость, например Redis
	/// Используем thread-safe имплементацию, чтобы избежать длительных блокирующих операций семейства Monitor
	/// и обеспечить эффективный (относительно) многопоточный доступ к инкапсулированным данным
	/// Хранилище зарегистрировано в IoC как Singleton
	/// Альтернативой может быть более сложная реализация на основе диапазонов хранения данных, в виде какого-то, к примеру, пула хранилищ
	/// (некоторая наивная имплементация распределенного хранилища). Здесь, для простоты не будем ничего изобретать
	///  </summary>
	public class KeyValueStorageDictionary : IKeyValueStorage
	{
		private readonly ConcurrentDictionary<object, object> _keyValueStorageDictionary = new ConcurrentDictionary<object, object>();

		/// <summary>
		/// Если верить J.Skeet http://csharpindepth.com/Articles/General/Singleton.aspx
		/// потокобезопасная инициализация Singleton, на мой взгляд наиболее лаконичная из всех вариантов  
		/// </summary>
		// ReSharper disable once EmptyConstructor
		static KeyValueStorageDictionary()
		{
		}

		public Task<object> Read(string key)
		{
			_keyValueStorageDictionary.TryGetValue(key, out object result);
			return Task.FromResult(result);
		}

		public Task Update(string key, object value)
		{
			//поскольку в требованиях не указано явно иного,
			//поступаем по принципу, кто последний - тот и вставил
			return Task.FromResult(_keyValueStorageDictionary.AddOrUpdate(key, value, (present, current) => value));
		}

		public Task<bool> Delete(string key)
		{
			return Task.FromResult(_keyValueStorageDictionary.TryRemove(key, out _));
		}
	}
}
