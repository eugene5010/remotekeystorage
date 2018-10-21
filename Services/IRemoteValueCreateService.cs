using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteKeyStorage.Services
{
	public interface IRemoteValueCreateService
	{
		Task Create(string key, object value);
	}
}
