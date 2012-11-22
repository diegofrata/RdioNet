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
using RdioNet.Models.Results;
using RdioNet.Serialization;
using RdioNet.Util;

#endregion

namespace RdioNet.Methods
{
	/// <summary>
	/// Playback methods of the Rdio API.
	/// </summary>
	public class PlaybackMethods : MethodsBase
	{
		#region Construction and Initialization

		public PlaybackMethods(RdioClient client)
			: base(client)
		{
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Get an playback token. If you are using this for web playback you must supply a domain.
		/// </summary>
		/// <param name="domain">The domain that the playback SWF will be embedded in.</param>
		/// <returns>Returns a playback token string.</returns>
		public Task<string> GetPlaybackTokenAsync(string domain)
		{
			if (string.IsNullOrEmpty(domain))
				throw new ArgumentNullException("domain");

			return PostAsync<string>("getPlaybackToken", new Dictionary<string, string>
			{
				{ "domain" , domain }
			});
		}

		#endregion
	}
}