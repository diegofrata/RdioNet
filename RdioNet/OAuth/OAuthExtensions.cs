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
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using OAuth;

#endregion

namespace RdioNet.Extensions
{
	internal static class OAuthExtensions
	{
		#region Public Methods

		public static HttpWebRequest CreateRequestWithAuthorizationHeader(this OAuthRequest instance, Uri requestUrl)
		{
			instance.RequestUrl = requestUrl.ToString();

			var request = (HttpWebRequest) WebRequest.Create(requestUrl);

			request.Method = instance.Method;
			request.Headers.Add("Authorization", instance.GetAuthorizationHeader());

			return request;
		}

		public static HttpWebRequest CreateRequestWithAuthorizationBody(this OAuthRequest instance, Uri requestUrl, Dictionary<string, string> parameters)
		{
			instance.RequestUrl = requestUrl.ToString();

			var builder = new UriBuilder(requestUrl);

			var request = (HttpWebRequest) WebRequest.Create(builder.Uri);

			request.Method = instance.Method;

			RemoveNullEntries(parameters);

			using (var writer = new StreamWriter(request.GetRequestStream()))
			{
				writer.Write(instance.GetAuthorizationQuery(parameters));
				writer.Write(OAuthTools.NormalizeRequestParameters(new WebParameterCollection(parameters)));
				writer.Close();
			}

			return request;
		}

		public static OAuth.OAuthRequestState GetAuthorizationState(this HttpWebResponse instance)
		{
			using (var reader = new StreamReader(instance.GetResponseStream()))
			{
				var dictionary = HttpUtility.ParseQueryString(reader.ReadToEnd());

				var builder = new UriBuilder(dictionary["login_url"]);
				builder.Query = string.Format("oauth_token={0}", dictionary["oauth_token"]);

				return new OAuth.OAuthRequestState
				{
					AuthorizationUrl = builder.Uri,
					CallbackConfirmed = dictionary["oauth_callback_confirmed"] == "true",
					RequestToken = new OAuth.OAuthToken
					{
						Secret = dictionary["oauth_token_secret"],
						Token = dictionary["oauth_token"],
						Type = OAuth.OAuthTokenType.Request
					}
				};
			}
		}

		public static OAuth.OAuthToken GetToken(this HttpWebResponse instance)
		{
			using (var reader = new StreamReader(instance.GetResponseStream()))
			{
				var dictionary = HttpUtility.ParseQueryString(reader.ReadToEnd());

				return new OAuth.OAuthToken
				{
					Secret = dictionary["oauth_token_secret"],
					Token = dictionary["oauth_token"],
					Type = OAuth.OAuthTokenType.Access
				};
			}
		}

		public static OAuthRequest ForProtectedResources(string method, OAuth.OAuthCredentials credentials)
		{
			OAuthRequest request;

			if (credentials.Token != null && credentials.Token.Type == OAuth.OAuthTokenType.Access)
			{
				request = OAuthRequest.ForProtectedResource(method,
														credentials.ConsumerKey,
														credentials.ConsumerSecret,
														credentials.Token.Token,
														credentials.Token.Secret);
			}
			else
				request = OAuthRequest.ForProtectedResource(method, credentials.ConsumerKey, credentials.ConsumerSecret, null, null);

			// OAuth isn't setting the Method correctly.
			request.Method = method.ToUpperInvariant();

			return request;
		}

		#endregion

		#region Private Methods

		private static void RemoveNullEntries(Dictionary<string, string> parameters)
		{
			var entries = parameters.Where(p => p.Value == null).Select(p => p.Key).ToArray();

			foreach (var key in entries)
				parameters.Remove(key);
		}

		#endregion
	}
}