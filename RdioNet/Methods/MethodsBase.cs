#region Header

// Copyright (c) 2012 Diego Frata
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software
// and associated documentation files (the "Software"), to deal in the Software without restriction,
// including without limitation the rights to use, copy, modif/ merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do
// so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial
// portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT
// NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
// SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

#endregion

#region Using Statements

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OAuth;
using RdioNet.Extensions;
using RdioNet.Models;
using RdioNet.Models.Results;
using RdioNet.Serialization;

#endregion

namespace RdioNet.Methods
{
	/// <summary>
	/// Class that implements the basic functionality required to call Rdio API's methods.
	/// </summary>
	public abstract class MethodsBase
	{
		#region Member Variables

		private RdioClient _client;

		#endregion

		#region Construction and Initialization

		public MethodsBase(RdioClient client)
		{
			if (client == null)
				throw new ArgumentNullException("client");

			_client = client;
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Asynchronously calls a method with the POST verb.
		/// </summary>
		/// <typeparam name="TResult">The type of the deserialized result.</typeparam>
		/// <param name="method">The name of the method being called.</param>
		/// <param name="parameters">Any required and optional parameters used by the method.</param>
		/// <returns>The deserialized result of the call.</returns>
		public Task<TResult> PostAsync<TResult>(string method, Dictionary<string, string> parameters)
		{
			return RequestAsync<TResult>("POST", method, parameters);
		}

		#endregion

		#region Private Methods

		private async Task<TResult> RequestAsync<TResult>(string httpMethod, string method, Dictionary<string, string> parameters)
		{
			try
			{
				var request = OAuthExtensions.ForProtectedResources(httpMethod, _client.Credentials);

				var data = new Dictionary<string, string>(parameters);
				data.Add("method", method);

				var httpRequest = request.CreateRequestWithAuthorizationBody(_client.ServiceDescription.WebServiceEndpoint, data);
				httpRequest.ContentType = "application/x-www-form-urlencoded";

				using (var httpResponse = await httpRequest.GetHttpWebResponseAsync())
				{
					httpResponse.EnsureSuccessStatusCode();

					using (var reader = new StreamReader(httpResponse.GetResponseStream()))
					{
						var serializedResult = await reader.ReadToEndAsync();

						var result = Serializer.Deserialize<RdioResult<TResult>>(serializedResult);

						if (!string.Equals(result.Status, "ok", StringComparison.InvariantCultureIgnoreCase))
							throw new RdioException(result.Message);

						return result.Result;
					}
				}
			}
			catch (RdioException)
			{
				// It is already an RdioException, no need to do anything, just throw it.
				throw;
			}
			catch (Exception ex)
			{
				throw new RdioException("Couldn't complete the request to the server", ex);
			}
		}

		#endregion
	}
}