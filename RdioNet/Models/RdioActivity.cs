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

using Newtonsoft.Json;

#endregion

namespace RdioNet.Models
{
	/// <summary>
	/// Represents an collection of recent activity	of an user.
	/// </summary>
	public class RdioActivity
	{
		#region Public Properties

		/// <summary>
		/// The last update id for the user's activity stream.
		/// </summary>
		[JsonProperty("last_id")]
		public int LastId
		{
			get;
			set;
		}

		/// <summary>
		/// The user to which all activity is related.
		/// </summary>
		public RdioUser User
		{
			get;
			set;
		}

		/// <summary>
		/// A list of recent activity updates. Check the <seealso cref="NS:RdioNet.Models.Activities"/> namespace
		/// for a list of possible object types.
		/// </summary>
		public IList<RdioActivityUpdate> Updates
		{
			get;
			set;
		}

		#endregion
	}
}