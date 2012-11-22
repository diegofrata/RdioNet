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
	/// Represents a song on Rdio.
	/// </summary>
	[DebuggerDisplay("{TrackNum,nq}. {Name,nq}")]
	public class RdioTrack : RdioObject
	{
		#region Public Properties

		/// <summary>
		/// THe name of the track.
		/// </summary>
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// The name of the artist who performed the track.
		/// </summary>
		public string Artist
		{
			get;
			set;
		}

		/// <summary>
		/// The name of the album that the track appears on.
		/// </summary>
		public string Album
		{
			get;
			set;
		}

		/// <summary>
		/// The key of the album that the track appears on.
		/// </summary>
		public string AlbumKey
		{
			get;
			set;
		}

		/// <summary>
		/// The relative URL of the album that the track appears on.
		/// </summary>
		public string AlbumUrl
		{
			get;
			set;
		}

		/// <summary>
		/// The key of the track's artist.
		/// </summary>
		public string ArtistKey
		{
			get;
			set;
		}

		/// <summary>
		/// The relative URL of the track's artist on the Rdio web site.
		/// </summary>
		public string ArtistUrl
		{
			get;
			set;
		}

		/// <summary>
		/// The number of tracks in the track, i.e. 1.
		/// </summary>
		public int Length
		{
			get;
			set;
		}

		/// <summary>
		/// The duration of the track.
		/// </summary>
		public TimeSpan Duration
		{
			get;
			set;
		}

		/// <summary>
		/// Identifies if the track is explicit.
		/// </summary>
		public bool IsExplicit
		{
			get;
			set;
		}

		/// <summary>
		/// Identifies if the track is clean.
		/// </summary>
		public bool IsClean
		{
			get;
			set;
		}

		/// <summary>
		/// The relative URL of the track on the Rdio web site.
		/// </summary>
		public string Url
		{
			get;
			set;
		}

		/// <summary>
		/// The relative URL of the album-art for the track.
		/// </summary>
		public string BaseIcon
		{
			get;
			set;
		}

		/// <summary>
		/// The name of the artist whose album the track appears on.
		/// </summary>
		public string AlbumArtist
		{
			get;
			set;
		}

		/// <summary>
		/// The key of the artist whose album the track appears on.
		/// </summary>
		public string AlbumArtistKey
		{
			get;
			set;
		}

		/// <summary>
		/// Identifies if the track can be downloaded.
		/// </summary>
		public bool CanDownload
		{
			get;
			set;
		}

		/// <summary>
		/// Identifies if the track can only be downloaded as part of an album download.
		/// </summary>
		public bool CanDownloadAlbumOnly
		{
			get;
			set;
		}

		/// <summary>
		/// Identifies if the track can be streamed.
		/// </summary>
		public bool CanStream
		{
			get;
			set;
		}

		/// <summary>
		/// Identifies if the track can be synchronized to mobile devices.
		/// </summary>
		public bool CanTether
		{
			get;
			set;
		}

		/// <summary>
		/// Identifies if the track can be previewed.
		/// </summary>
		public bool CanSample
		{
			get;
			set;
		}

		/// <summary>
		/// The price of the track in US cents.
		/// </summary>
		public string Price
		{
			get;
			set;
		}

		/// <summary>
		/// A short URL for the track.
		/// </summary>
		public Uri ShortUrl
		{
			get;
			set;
		}

		/// <summary>
		/// The URL of a SWF to embed the track.
		/// </summary>
		public Uri EmbedUrl
		{
			get;
			set;
		}

		/// <summary>
		/// The URL of the album-art for the track.
		/// </summary>
		public Uri Icon
		{
			get;
			set;
		}

		/// <summary>
		/// The order within its album that this track appears.
		/// </summary>
		public int TrackNum
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. Identifies if the track is in the user's collection.
		/// </summary>
		public bool? IsInCollection
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. Identfieis if the track is on a compilation album.
		/// </summary>
		public bool? IsOnCompilation
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. The URL of an IFRAME to embed the album.
		/// </summary>
		public Uri IFrameUrl
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. The number of times this track has been played on Rdio.
		/// </summary>
		public int? PlayCount
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. The URL to the album-art for track (large).
		/// </summary>
		public Uri BigIcon
		{
			get;
			set;
		}

		/// <summary>
		/// List of extra properties.
		/// </summary>
		public static RdioTrackExtras Extras
		{
			get
			{
				return Singleton<RdioTrackExtras>.Instance;
			}
		}

		#endregion
	}
}