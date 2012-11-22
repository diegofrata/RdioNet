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
	/// Represents a playlist on Rdio.
	/// </summary>
	[DebuggerDisplay("{Name} by {Owner} [{Length,nq} tracks]")]
	public class RdioPlaylist : RdioObject
	{
		#region Public Properties

		/// <summary>
		/// The name of the playlist.
		/// </summary>
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// The number of tracks in the playlist.
		/// </summary>
		public int Length
		{
			get;
			set;
		}

		/// <summary>
		/// The relative URL of the playlist on the Rdio web site.
		/// </summary>
		public string Url
		{
			get;
			set;
		}

		/// <summary>
		/// The URL of an icon for the playlist.
		/// </summary>
		public Uri Icon
		{
			get;
			set;
		}

		/// <summary>
		/// The relative URI of an icon for the playlist.
		/// </summary>
		public string BaseIcon
		{
			get;
			set;
		}

		/// <summary>
		/// The name of the user who created the playlist.
		/// </summary>
		public string Owner
		{
			get;
			set;
		}

		/// <summary>
		/// The relative URL on the Rdio site of the user who created the playlist.
		/// </summary>
		public string OwnerUrl
		{
			get;
			set;
		}

		/// <summary>
		/// The key of the user who created the playlist.
		/// </summary>
		public string OwnerKey
		{
			get;
			set;
		}

		/// <summary>
		/// The relative URL of the icon of the user who created the playlist.
		/// </summary>
		public string OwnerIcon
		{
			get;
			set;
		}

		/// <summary>
		/// When the playlist was last modified.
		/// </summary>
		public DateTime LastUpdated
		{
			get;
			set;
		}

		/// <summary>
		/// A short URL for the playlist page.
		/// </summary>
		public Uri ShortUrl
		{
			get;
			set;
		}

		/// <summary>
		/// The URL of a SWF to embed the playlist.
		/// </summary>
		public Uri EmbedUrl
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
		/// Extra. Identifies wether the playlist is currently publicly viewable.
		/// </summary>
		public bool? IsViewable
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. The URL of an icon for the playlist (large).
		/// </summary>
		public Uri BigIcon
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. The description of the playlist.
		/// </summary>
		public string Description
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. The tracks in the playlist.
		/// </summary>
		public IList<RdioTrack> Tracks
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. Identifies wether the playlist has been published by the user.
		/// </summary>
		public bool? IsPublished
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. The keys of the tracks in the playlist.
		/// </summary>
		public IList<string> TrackKeys
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. Identifies the reason the playlist is not publicly viewable, if there's one.
		/// </summary>
		public RdioPlaylistVisibilityReason? ReasonNotViewable
		{
			get;
			set;
		}

		/// <summary>
		/// List of extra properties.
		/// </summary>
		public static RdioPlaylistExtras Extras
		{
			get
			{
				return Singleton<RdioPlaylistExtras>.Instance;
			}
		}

		#endregion
	}
}