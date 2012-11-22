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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace RdioNet.Models
{
	/// <summary>
	/// Represents a record label.
	/// </summary>
	[DebuggerDisplay("{Name,nq}")]
	public class RdioLabel : RdioObject
	{
		#region Public Properties

		/// <summary>
		/// The name of the artist.
		/// </summary>
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// The relative URL of the label on the Rdio web site.
		/// </summary>
		public string Url
		{
			get;
			set;
		}

		/// <summary>
		/// A short URL for the label page.
		/// </summary>
		public Uri ShortUrl
		{
			get;
			set;
		}

		/// <summary>
		/// Identifies if the label has a radio station available on Rdio. 
		/// </summary>
		public bool HasRadio
		{
			get;
			set;
		}

		/// <summary>
		/// The key of the station for label recommendations.
		/// </summary>
		public string RadioKey
		{
			get;
			set;
		}

		#endregion
	}
}