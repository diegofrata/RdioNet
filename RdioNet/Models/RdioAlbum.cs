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
	/// Represents a recording on Rdio, usually an album but often a single, EP or compilation.
	/// </summary>
	[DebuggerDisplay("{Name} by {Artist} ({ReleaseDate.ToString(\"yyyy\"),nq})")]
	public class RdioAlbum : RdioObject
	{
		#region Public Properties

		/// <summary>
		/// The name of the album.
		/// </summary>
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// The URL to the cover art for the album. Usually 200x200 pixels.
		/// </summary>
		public Uri Icon
		{
			get;
			set;
		}

		/// <summary>
		/// The relative URL to the cover art of the album. See <see cref="Icon"/> or <see cref="BigIcon"/>
		/// for a working URL.
		/// </summary>
		public string BaseIcon
		{
			get;
			set;
		}

		/// <summary>
		/// The relative URL of the album on Rdio site.
		/// </summary>
		public string Url
		{
			get;
			set;
		}

		/// <summary>
		/// The name of the artist that released the album.
		/// </summary>
		public string Artist
		{
			get;
			set;
		}

		/// <summary>
		/// The relative URL of the artist that released the album.
		/// </summary>
		public string ArtistUrl
		{
			get;
			set;
		}

		/// <summary>
		/// Identifies if the album is explicit.
		/// </summary>
		public bool IsExplicit
		{
			get;
			set;
		}

		/// <summary>
		/// Identifies if the album is clean.
		/// </summary>
		public bool IsClean
		{
			get;
			set;
		}

		/// <summary>
		/// Number of tracks in the album.
		/// </summary>
		public int Length
		{
			get;
			set;
		}

		/// <summary>
		/// The key of the artist that released the album. Can be used to query the artist on <seealso cref="RdioClient"/>. 
		/// See also <seealso cref="RdioArtist"/>.
		/// </summary>
		public string ArtistKey
		{
			get;
			set;
		}

		/// <summary>
		/// The keys of the tracks in the album. Can be used to query the track on <seealso cref="RdioClient"/>.
		/// See also <seealso cref="RdioTrack"/>.
		/// </summary>
		public IList<string> TrackKeys
		{
			get;
			set;
		}

		/// <summary>
		/// The price of the album in US cents.
		/// </summary>
		public string Price
		{
			get;
			set;
		}

		/// <summary>
		/// Identifies if the album can be streamed.
		/// </summary>
		public bool CanStream
		{
			get;
			set;
		}

		/// <summary>
		/// Identifies if the album can be previewed.
		/// </summary>
		public bool CanSample
		{
			get;
			set;
		}

		/// <summary>
		/// Identifies if the album can be synchronized to mobile devices.
		/// </summary>
		public bool CanTether
		{
			get;
			set;
		}

		/// <summary>
		/// A shortened Url for the album on Rdio website.
		/// </summary>
		public Uri ShortUrl
		{
			get;
			set;
		}

		/// <summary>
		/// A shortened Url of a SWF to embed the album.
		/// </summary>
		public Uri EmbedUrl
		{
			get;
			set;
		}

		/// <summary>
		/// The release date of the album in a human readable format. See <see cref="ReleaseDate"/>.
		/// </summary>
		/// <remarks>
		/// The date is localized to US. Please use <see cref="ReleaseDate"/> instead for more control over the format.
		/// </remarks>
		public string DisplayDate
		{
			get;
			set;
		}

		/// <summary>
		/// The release date of the album. 
		/// </summary>
		public DateTime ReleaseDate
		{
			get;
			set;
		}

		/// <summary>
		/// The duration of the album.
		/// </summary>
		public TimeSpan Duration
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. The Url of an HTML IFrame to embed the album.
		/// </summary>
		public Uri IFrameUrl
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. Identifies if this is a compilation album.
		/// </summary>
		public bool? IsCompilation
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. The label that published this album.
		/// </summary>
		public RdioLabel Label
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. The Url for the cover art of the album (large).
		/// </summary>
		public Uri BigIcon
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. The release date of the album in ISO format. Use <see cref="ReleaseDate"/> instead.
		/// </summary>
		/// <remarks>
		/// This field is included only for API compliance purposes. Should not be used.
		/// </remarks>
		public DateTime? ReleaseDateIso
		{
			get;
			set;
		}

		/// <summary>
		/// Sometimes. Indicates the popularity weight.
		/// </summary>
		/// <remarks>
		/// This field is returned when calling GetHeavyRotationsAsync.
		/// </remarks>
		public int? Hits
		{
			get;
			set;
		}

		/// <summary>
		/// List of extra properties.
		/// </summary>
		public static RdioAlbumExtras Extras
		{
			get
			{
				return Singleton<RdioAlbumExtras>.Instance;
			}
		}

		#endregion
	}
}