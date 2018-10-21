using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nancy;

namespace RemoteKeyStorage.Exceptions
{
	public class ErrorCodeException : Exception
	{
		private readonly HttpStatusCode _statusCode;

		public ErrorCodeException(HttpStatusCode statusCode)
		{
			_statusCode = statusCode;
		}

		public ErrorCodeException(HttpStatusCode statusCode, Exception innerException)
			: base(null, innerException)
		{
			_statusCode = statusCode;
		}

		public ErrorCodeException(HttpStatusCode statusCode, string message, Exception innerException)
			: base(message, innerException)
		{
			_statusCode = statusCode;
		}

		public override string Message => string.Join(";", new[]
					{
						base.Message,
						InnerException != null && !string.IsNullOrWhiteSpace(InnerException.Message) ? InnerException.Message : null
					}
					.Where(x => !string.IsNullOrWhiteSpace(x)));

		public HttpStatusCode StatusCode
		{
			get { return _statusCode; }
		}
	}
}
