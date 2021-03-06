﻿#region Header

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

namespace RdioNet.OAuth
{
	/// <summary>
	/// Represents an OAuth token.
	/// </summary>
	public class OAuthToken
	{
		#region Public Properties

		/// <summary>
		/// The token.
		/// </summary>
		public string Token
		{
			get;
			set;
		}

		/// <summary>
		/// The token's secret.
		/// </summary>
		public string Secret
		{
			get;
			set;
		}

		/// <summary>
		/// The type of the token.
		/// </summary>
		public OAuthTokenType Type
		{
			get;
			set;
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Performs a copy of the object.
		/// </summary>
		/// <returns>Returns a new copy of the object.</returns>
		public OAuthToken Copy()
		{
			return new OAuthToken
			{
				Token = Token,
				Secret = Secret,
				Type = Type
			};
		}

		#endregion
	}
}