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
	/// Represents an artist on Rdio, either an individual performer or a group.
	/// </summary>
	[DebuggerDisplay("{Name,nq}")]
	public class RdioArtist : RdioObject
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
		/// The relative URL of the artist on the Rdio web site.
		/// </summary>
		public string Url
		{
			get;
			set;
		}

		/// <summary>
		/// The number of tracks that the artist has on Rdio.
		/// </summary>
		public int Length
		{
			get;
			set;
		}

		/// <summary>
		/// An image for the artist.
		/// </summary>
		public Uri Icon
		{
			get;
			set;
		}

		/// <summary>
		/// The partial URL of an image for the artist.
		/// </summary>
		public string BaseIcon
		{
			get;
			set;
		}

		/// <summary>
		/// Identifies if the artist has a radio available on Rdio. 
		/// </summary>
		public bool HasRadio
		{
			get;
			set;
		}

		/// <summary>
		/// A short URL for the artist page.
		/// </summary>
		public Uri ShortUrl
		{
			get;
			set;
		}

		/// <summary>
		/// The key of the station for artist recommendations.
		/// </summary>
		public string RadioKey
		{
			get;
			set;
		}

		/// <summary>
		/// The key of the station for the artist's top songs.
		/// </summary>
		public string TopSongsKey
		{
			get;
			set;
		}

		/// <summary>
		/// Extra. The number of albums that the artist has on Rdio.
		/// </summary>
		public int? AlbumCount
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
		public static RdioArtistExtras Extras
		{
			get
			{
				return Singleton<RdioArtistExtras>.Instance;
			}
		}

		#endregion
	}
}