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

namespace RdioNet.Models.Results
{
	/// <summary>
	/// Defines a result for Search method.
	/// </summary>
	/// <typeparam name="T">The type of the expected object or <seealso cref="RdioObject"/> if the type is not known.</typeparam>
	public class RdioSearchResult<T>
	{
		#region Public Properties

		/// <summary>
		/// The total number of objects found by the query (it is not the number of objects returned).
		/// </summary>
		[JsonProperty("number_results")]
		public int NumberOfResults
		{
			get;
			set;
		}

		/// <summary>
		/// The resulting objects of the search.
		/// </summary>
		public IList<T> Results
		{
			get;
			set;
		}

		/// <summary>
		/// The count of objects of type <seealso cref="RdioUser"/>.
		/// </summary>
		[JsonProperty("person_count")]
		public int? PersonCount
		{
			get;
			set;
		}

		/// <summary>
		/// The count of objects of type <seealso cref="RdioTrack"/>.
		/// </summary>
		[JsonProperty("track_count")]
		public int? TrackCount
		{
			get;
			set;
		}

		/// <summary>
		/// The count of objects of type <seealso cref="RdioAlbum"/>.
		/// </summary>
		[JsonProperty("album_count")]
		public int? AlbumCount
		{
			get;
			set;
		}

		/// <summary>
		/// The count of objects of type <seealso cref="RdioPlaylist"/>.
		/// </summary>
		[JsonProperty("playlist_count")]
		public int? PlaylistCount
		{
			get;
			set;
		}

		/// <summary>
		/// The count of objects of type <seealso cref="RdioArtist"/>.
		/// </summary>
		[JsonProperty("artist_count")]
		public int? ArtistCount
		{
			get;
			set;
		}

		#endregion
	}
}