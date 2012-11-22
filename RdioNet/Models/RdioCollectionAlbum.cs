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

using RdioNet.Models.Extras;
using RdioNet.Util;

#endregion

namespace RdioNet.Models
{
	/// <summary>
	/// Represents an album in a user's collection. It is basically the same as the equivalent Album type
	/// except that it will only contain the subset of tracks from the album that the user has in their collection.
	/// </summary>
	[DebuggerDisplay("{Name} by {Artist} ({ReleaseDate.ToString(\"yyyy\"),nq})")]
	public class RdioCollectionAlbum : RdioAlbum
	{
		#region Public Properties

		/// <summary>
		/// The key of the user whose collection this album is in.
		/// </summary>
		public string UserKey
		{
			get;
			set;
		}

		/// <summary>
		/// The username of the user whose collection this album is in.
		/// </summary>
		public string Username
		{
			get;
			set;
		}

		/// <summary>
		/// The key of the original album.
		/// </summary>
		public string AlbumKey
		{
			get;
			set;
		}

		/// <summary>
		/// The relative URL of the original album.
		/// </summary>
		public string AlbumUrl
		{
			get;
			set;
		}

		/// <summary>
		/// The relative URL for the user's collection page. This item doesn't seem to be provided.
		/// </summary>
		public string CollectionUrl
		{
			get;
			set;
		}

		/// <summary>
		/// A list of all the track keys contained in the original album.
		/// </summary>
		public IList<string> ItemTrackKeys
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. The user's gender.
		/// </summary>
		public RdioUserGender? UserGender
		{
			get; set;
		}

		/// <summary>
		/// List of extra properties.
		/// </summary>
		public static new RdioCollectionAlbumExtras Extras
		{
			get
			{
				return Singleton<RdioCollectionAlbumExtras>.Instance;
			}
		}

		#endregion
	}
}