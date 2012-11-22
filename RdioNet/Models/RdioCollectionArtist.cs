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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RdioNet.Models.Extras;
using RdioNet.Util;

#endregion

namespace RdioNet.Models
{
	/// <summary>
	/// Represents an artist in a user's collection. It will be basically the same as the 
	/// equivalent Artist except it only contains the albums that are in the user's collection.
	/// </summary>
	[DebuggerDisplay("{Name,nq}")]
	public class RdioCollectionArtist : RdioArtist
	{
		#region Public Properties

		/// <summary>
		/// The key of the user whose collection this artist is in.
		/// </summary>
		public string UserKey
		{
			get;
			set;
		}

		/// <summary>
		/// The username of the user whose collection this artist is in.
		/// </summary>
		public string Username
		{
			get;
			set;
		}

		/// <summary>
		/// The key of the artist.
		/// </summary>
		public string ArtistKey
		{
			get;
			set;
		}

		/// <summary>
		/// The relative URL of the artist.
		/// </summary>
		public string ArtistUrl
		{
			get;
			set;
		}

		/// <summary>
		/// The relative URL of the user's collection page.	This item doesn't seem to be provided.
		/// </summary>
		public string CollectionUrl
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. The number of tracks from this artist in the user collection.
		/// </summary>
		public int? Count
		{
			get;
			set;
		}

		/// <summary>
		/// List of extra properties.
		/// </summary>
		public static new RdioCollectionArtistExtras Extras
		{
			get
			{
				return Singleton<RdioCollectionArtistExtras>.Instance;
			}
		}

		#endregion
	}
}