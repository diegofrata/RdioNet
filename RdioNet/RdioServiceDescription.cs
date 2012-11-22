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

#endregion

namespace RdioNet
{
	/// <summary>
	/// Defines the OAuth and WebService endpoints.
	/// </summary>
	public sealed class RdioServiceDescription
	{
		#region Public Properties

		/// <summary>
		/// The default service description.
		/// </summary>
		public static RdioServiceDescription Default
		{
			get;
			set;
		}

		/// <summary>
		/// The OAuth AccessToken endpoing.
		/// </summary>
		public Uri AccessTokenEndpoint
		{
			get;
			set;
		}

		/// <summary>
		/// The OAuth RequestToken endpoint.
		/// </summary>
		public Uri RequestTokenEndpoint
		{
			get;
			set;
		}

		/// <summary>
		/// The Rdio API web service endpoint.
		/// </summary>
		public Uri WebServiceEndpoint
		{
			get;
			set;
		}

		/// <summary>
		/// The default CDN endpoint for images.
		/// </summary>
		public Uri MediaEndpoint
		{
			get;
			set;
		}

		#endregion

		#region Construction and Initialization

		static RdioServiceDescription()
		{
			Default = new RdioServiceDescription
			{
				AccessTokenEndpoint = new Uri("http://api.rdio.com/oauth/access_token"),
				MediaEndpoint = new Uri("http://cdn3.rdio.com"),
				RequestTokenEndpoint = new Uri("http://api.rdio.com/oauth/request_token"),
				WebServiceEndpoint = new Uri("http://api.rdio.com/1/")
			};
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Creates a new copy of the service description.
		/// </summary>
		/// <returns>Returns a new copy of the service description.</returns>
		public RdioServiceDescription Copy()
		{
			return new RdioServiceDescription
			{
				AccessTokenEndpoint = AccessTokenEndpoint,
				MediaEndpoint = MediaEndpoint,
				RequestTokenEndpoint = RequestTokenEndpoint,
				WebServiceEndpoint = WebServiceEndpoint
			};
		}

		#endregion
	}
}