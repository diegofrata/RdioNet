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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RdioNet.Models;
using RdioNet.Serialization;
using RdioNet.Util;

#endregion

namespace RdioNet.Methods
{
	/// <summary>
	/// Core methods of the Rdio API.
	/// </summary>
	public sealed class CoreMethods : MethodsBase
	{
		#region Construction and Initialization

		public CoreMethods(RdioClient client)
			: base(client)
		{
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Fetches one object from Rdio.
		/// </summary>
		/// <param name="key">The key of the object being fetched.</param>
		/// <param name="extras">The extra fields to be included in the object.</param>
		/// <returns>Returns an object whose key are the key supplied to the call. 
		/// This object can be of any type. If the returned object is not of type <typeparam name="T"/>
		/// an exception will be thrown.</returns>
		public Task<T> GetAsync<T>(string key, params string[] extras) where T : RdioObject
		{
			return GetAsync<T>(key, null, extras);
		}

		/// <summary>
		/// Fetches one object from Rdio.
		/// </summary>
		/// <param name="key">The key of the object being fetched.</param>
		/// <param name="extras">The extra fields to be included in the object.</param>
		/// <param name="options">A dictionary of undocumented options.</param>
		/// <returns>Returns an object whose key are the key supplied to the call. 
		/// This object can be of any type. If the returned object is not of type <typeparam name="T"/>
		/// an exception will be thrown.</returns>
		public async Task<T> GetAsync<T>(string key, IDictionary<string, string> options, params string[] extras) where T : RdioObject
		{
			if (string.IsNullOrEmpty(key))
				throw new ArgumentNullException("key");

			if (key.Contains(","))
				throw new ArgumentException("The parameter cannot contain multiple keys. Use the correct overload for multiple keys.", "key");

			var items = await GetAsync<T>(new[] { key }, options, extras);

			return items.Values.FirstOrDefault();
		}

		/// <summary>
		/// Fetches multiple objects from Rdio.
		/// </summary>
		/// <param name="key">The keys of the objects being fetched.</param>
		/// <param name="extras">The extra fields to be included in the object.</param>
		/// <returns>Returns a dictionary of objects whose keys are the keys supplied to the call. 
		/// This object can be of any type. If the returned object is not of type <typeparam name="T"/>
		/// an exception will be thrown.</returns>
		public Task<IDictionary<string, T>> GetAsync<T>(IEnumerable<string> keys, params string[] extras) where T : RdioObject
		{
			return GetAsync<T>(keys, null, extras);
		}

		/// <summary>
		/// Fetches multiple objects from Rdio.
		/// </summary>
		/// <param name="key">The keys of the objects being fetched.</param>
		/// <param name="extras">The extra fields to be included in the object.</param>	
		/// <param name="options">A dictionary of undocumented options.</param>
		/// <returns>Returns a dictionary of objects whose keys are the keys supplied to the call. 
		/// This object can be of any type. If the returned object is not of type <typeparam name="T"/>
		/// an exception will be thrown.</returns>
		public Task<IDictionary<string, T>> GetAsync<T>(IEnumerable<string> keys, IDictionary<string, string> options, params string[] extras) where T : RdioObject
		{
			return PostAsync<IDictionary<string, T>>("get", new Dictionary<string, string> 
			{ 
				{ "keys", keys.ToCommaSeparatedList() },
				{ "extras", extras.ToCommaSeparatedList() },
				{ "options", options.ToJsonDictionary() }
			});
		}

		/// <summary>
		/// Gets the object that the supplied Rdio short-code is a representation of, or an error if the short-code is invalid.
		/// </summary>
		/// <param name="shortCode">The short-code, everything after the http://rd.io/x/. </param>
		/// <param name="extras">The extra fields to be included in the object.</param>
		/// <returns>Returns the object that the short-code links to, or an empty object if the short-code is invalid or doesn't link anywhere.</returns>
		public Task<T> GetObjectFromShortCodeAsync<T>(string shortCode, params string[] extras) where T : RdioObject
		{
			if (string.IsNullOrEmpty(shortCode))
				throw new ArgumentNullException("shortCode");

			return PostAsync<T>("getObjectFromShortCode", new Dictionary<string, string> 
			{ 
				{ "short_code", shortCode },
				{ "extras", extras.ToCommaSeparatedList() }
			});
		}

		/// <summary>
		/// Return the object that the supplied Rdio url is a representation of, or 404 error response if the url doesn't represent an object.
		/// </summary>
		/// <param name="url">The path portion of the url</param>
		/// <param name="extras"></param>
		/// <returns>Returns the object represented at the url, or a 404 error response if the url doesn't point to page representing an object.</returns>
		public Task<T> GetObjectFromUrlAsync<T>(string url, params string[] extras) where T : RdioObject
		{
			if (string.IsNullOrEmpty(url))
				throw new ArgumentNullException("url");

			return PostAsync<T>("getObjectFromUrl", new Dictionary<string, string> 
			{ 
				{ "url", url },
				{ "extras", extras.ToCommaSeparatedList() }
			});
		}

		#endregion
	}
}