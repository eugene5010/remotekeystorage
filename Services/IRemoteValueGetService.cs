using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteKeyStorage.Services
{
	public interface IRemoteValueGetService
	{
		Task<object> Get(string key);
	}
}
