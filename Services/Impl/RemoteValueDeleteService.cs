using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RemoteKeyStorage.Persistence;

namespace RemoteKeyStorage.Services.Impl
{
	internal class RemoteValueDeleteService : IRemoteValueDeleteService
	{
		private readonly IKeyValueStorage _keyValueStorage;

		public RemoteValueDeleteService(IKeyValueStorage keyValueStorage)
		{
			_keyValueStorage = keyValueStorage;
		}

		public async Task<bool> Delete(string key)
		{
			return await _keyValueStorage.Delete(key);
		}
	}
}
